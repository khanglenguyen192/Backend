using Backend.Common;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/report")]
    [ApiController]
    public class ReportController : BaseController
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService,
                                IUserService userService,
                                IWebHostEnvironment webHostEnvironment,
                                ILogger<BaseController> logger) : base(userService, webHostEnvironment, logger)
        {
            _reportService = reportService;
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("getDailyReportById")]
        [Authorize]
        public ResponseModel GetDailyReportById(int reportId)
        {
            if (reportId == 0) 
                return ResponseUtil.GetBadRequestResult(ErrorMessageCode.REPORT_NOT_FOUND);

            try
            {

                return ResponseUtil.GetOKResult(_reportService.GetDailyReportById(reportId));

            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("getDailyReports")]
        [Authorize]
        public ResponseModel GetDailyReports(int userId)
        {
            try
            {
                var result = _reportService.GetDailyReports(userId);

                return ResponseUtil.GetOKResult(result);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("createDailyReport")]
        [Authorize]
        public ResponseModel CreateDailyReport([FromBody] DailyReportModel model)
        {
            try
            {
                var result = _reportService.CreateDailyReport(model, CurrentUser.UserId);

                return ResponseUtil.GetOKResult(result);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }
    }
}
