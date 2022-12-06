using Backend.Common;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/meeting")]
    [ApiController]
    public class MeetingController : BaseController
    {
        private readonly IMeetingService _meetingService;
        public MeetingController(IMeetingService meetingService,
                                 IUserService userService,
                                 IWebHostEnvironment webHostEnvironment,
                                 ILogger<BaseController> logger) : base(userService, webHostEnvironment, logger)
        {
            _meetingService = meetingService;
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("createMeeting")]
        [Authorize]
        public ResponseModel CreateMeeting([FromBody] CreateMeetingModel model)
        {
            try
            {
                model.TimeStartDateTime = CommonUtils.ConvertDateTime(model.TimeStart, Constants.DATETIME_FORMAT);
                return GetOKResult(_meetingService.CreateMeeting(CurrentUser, model));
            }
            catch (Exception ex)
            {
                return GetServerErrorResult(ex.ToString());
            }
        }

        [HttpDelete]
        [Produces("application/json")]
        [Route("deleteMeeting")]
        [Authorize]
        public ResponseModel DeleteMeeting([FromBody] int meetingId)
        {
            try
            {
                return GetOKResult(_meetingService.DeleteMeeting(CurrentUser, meetingId));
            }
            catch (Exception ex)
            {
                return GetServerErrorResult(ex.ToString());
            }
        }
    }
}
