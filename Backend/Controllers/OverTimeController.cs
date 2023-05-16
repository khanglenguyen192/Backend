using Backend.Common;
using Backend.DBContext;
using Backend.Entities;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/overtime")]
    [ApiController]
    public class OverTimeController : BaseController
    {
        private readonly IOverTimeRepository _overTimeRepository;

        public OverTimeController(IUserService userService,
            IWebHostEnvironment webHostEnvironment,
            ILogger<BaseController> logger,
            IJwtHandler jwtHandler,
            IUserRepository userRepository,
            IOverTimeRepository overTimeRepository) 
            : base(userService, webHostEnvironment, logger, jwtHandler, userRepository)
        {
            _overTimeRepository = overTimeRepository;
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("create")]
        [Authorize]
        public ResponseModel CreateOverTime(OverTimeModel request)
        {
            try
            {
                if (!_userRepository.Exists(u => u.Id == request.UserId && !u.IsDeactivate))
                {
                    return ResponseUtil.GetBadRequestResult("user_not_exist");
                }

                if (request.TimeStart > request.TimeFinish)
                {
                    return ResponseUtil.GetBadRequestResult("invalid_start_time");
                }

                var hourDuration = request.TimeFinish - request.TimeStart;

                if (hourDuration.TotalHours < request.WorkTime)
                {
                    return ResponseUtil.GetBadRequestResult("invalid_work_time");
                }

                var overTime = _mapper.Map<OverTimeModel, OverTime>(request);
                overTime.Month = request.TimeStart;

                _overTimeRepository.Insert(overTime);

                return ResponseUtil.GetOKResult(overTime);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.Message);
            }
        }

        [HttpDelete]
        [Produces("application/json")]
        [Route("delete")]
        [Authorize]
        public ResponseModel DeleteOverTime(int overTimeId)
        {
            try
            {
                if (_overTimeRepository.Exists(o => o.Id == overTimeId))
                {
                    _overTimeRepository.Delete(overTimeId);
                    return ResponseUtil.GetOKResult("success");
                }

                return ResponseUtil.GetBadRequestResult("overtime_not_found");
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.Message);
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("get-by-user")]
        [Authorize]
        public ResponseModel GetOverTime(int userId)
        {
            try
            {
                if (!_userRepository.Exists(u => u.Id == userId))
                    return ResponseUtil.GetBadRequestResult("user_not_found");

                return ResponseUtil.GetOKResult(_overTimeRepository.GetAll(o => o.UserId == userId));
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.Message);
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("search")]
        [Authorize]
        public ResponseModel SearchOverTime(SearchOverTimeModel searchModel)
        {
            try
            {
                var result = _overTimeRepository.SearchOverTime(searchModel);

                return ResponseUtil.GetOKResult(result);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.Message);
            }
        }
    }
}
