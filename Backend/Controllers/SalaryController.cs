using Backend.Common;
using Backend.DBContext;
using Backend.Entities;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/salary")]
    [ApiController]
    public class SalaryController : BaseController 
    {
        private readonly ISalaryService _salaryService;

        private readonly ISalaryRepository _salaryRepository;

        private readonly IOverTimeRepository _overTimeRepository;

        public SalaryController(ISalaryService salaryService,
                                IUserService userService,
                                IWebHostEnvironment webHostEnvironment,
                                ILogger<BaseController> logger,
                                IJwtHandler jwtHandler,
                                IUserRepository userRepository,
                                ISalaryRepository salaryRepository,
                                IOverTimeRepository overTimeRepository)
            : base(userService, webHostEnvironment, logger, jwtHandler, userRepository)
        {
            _salaryService = salaryService;
            _salaryRepository = salaryRepository;
            _overTimeRepository = overTimeRepository;
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("getSalaries")]
        [Authorize(Roles = "Administrator")]
        public ResponseModel GetSalaries(List<int> listUserId)
        {
            try
            {
                return ResponseUtil.GetOKResult(_salaryService.GetSalaries(CurrentUser.UserId, listUserId, CommonUtils.GetLocalTimeNow(CurrentUser.TimeZoneInfo)));
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("get-by-user")]
        public ResponseModel GetSalary(int userId)
        {
            try
            {
                var user = _userRepository.FirstOrDefault(u => u.Id == userId && !u.IsDeactivate);
                if (user == null)
                    return ResponseUtil.GetBadRequestResult("user_not_found");

                var currentMonth = DateTime.UtcNow.Month;
                var currentYear = DateTime.UtcNow.Year;

                var salary = _salaryRepository.FirstOrDefault(u => u.Id == userId && currentMonth.Equals(u.Month.Month)
                    && currentYear.Equals(u.Month.Year));

                if (salary == null)
                {
                    salary = _salaryRepository.Insert(user);
                }

                if (salary == null)
                    return ResponseUtil.GetBadRequestResult("error");

                SalaryModel salaryModel = _mapper.Map<Salary, SalaryModel>(salary);

                salaryModel.RealSalary = salary.GetRealSalary();

                return ResponseUtil.GetOKResult(salaryModel);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }
    }
}
