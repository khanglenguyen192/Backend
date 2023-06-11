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
        private readonly ISalaryRepository _salaryRepository;

        public OverTimeController(IUserService userService,
            IWebHostEnvironment webHostEnvironment,
            ILogger<BaseController> logger,
            IJwtHandler jwtHandler,
            IUserRepository userRepository,
            IOverTimeRepository overTimeRepository,
            ISalaryRepository salaryRepository) 
            : base(userService, webHostEnvironment, logger, jwtHandler, userRepository)
        {
            _overTimeRepository = overTimeRepository;
            _salaryRepository = salaryRepository;
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

                UpdateUserSalary(overTime);

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
                var overTime = _overTimeRepository.FirstOrDefault(o => o.Id == overTimeId);

                if (overTime != null)
                {
                    _overTimeRepository.Delete(overTimeId);
                    UpdateUserSalary(overTime);
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

        private void UpdateUserSalary(OverTime overTime)
        {
            var user = _userRepository.FirstOrDefault(u => u.Id == overTime.UserId && !u.IsDeactivate);

            if (user == null)
                return;

            var currentMonth = overTime.Month.Month;

            var currentYear = overTime.Month.Year;

            var salary = _salaryRepository.FirstOrDefault(u => u.Id == overTime.UserId && currentMonth.Equals(u.Month.Month)
                && currentYear.Equals(u.Month.Year));

            if (salary == null)
            {
                salary = _salaryRepository.Insert(user);

                if (salary == null)
                    return;
            }

            var overTimes = _overTimeRepository.GetAll(o => o.UserId == user.Id && currentMonth.Equals(o.Month.Month)
                    && currentYear.Equals(o.Month.Year));

            if (overTimes.Any())
            {
                long total = 0;

                foreach (var ot in overTimes)
                {
                    total += (long)(ot.WorkTime * user.HourSalary);
                }

                salary.OTSalary = total;

                _salaryRepository.Update(salary);
            }
        }
    }
}
