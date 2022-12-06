using Backend.Common;
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

        public SalaryController(ISalaryService salaryService,
                                IUserService userService,
                                IWebHostEnvironment webHostEnvironment,
                                ILogger<BaseController> logger) : base(userService, webHostEnvironment, logger)
        {
            _salaryService = salaryService;
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("getSalaries")]
        [Authorize(Roles = "Administrator")]
        public ResponseModel GetSalaries(List<int> listUserId)
        {
            try
            {
                return ResponseHelper.GetOKResult(_salaryService.GetSalaries(CurrentUser.UserId, listUserId, CommonUtils.GetLocalTimeNow(CurrentUser.TimeZoneInfo)));
            }
            catch (Exception ex)
            {
                return ResponseHelper.GetServerErrorResult(ex.ToString());
            }
        }
    }
}
