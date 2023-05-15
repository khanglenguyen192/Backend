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
    }
}
