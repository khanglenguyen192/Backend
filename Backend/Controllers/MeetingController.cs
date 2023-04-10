using Backend.Common;
using Backend.DBContext;
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
                                 ILogger<BaseController> logger,
                                 IUserRepository userRepository)
            : base(userService, webHostEnvironment, logger, userRepository)
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
                return ResponseUtil.GetOKResult(_meetingService.CreateMeeting(CurrentUser, model));
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpDelete]
        [Produces("application/json")]
        [Route("removeMeeting")]
        [Authorize]
        public ResponseModel RemoveMeeting([FromBody] int meetingId)
        {
            try
            {
                return ResponseUtil.GetOKResult(_meetingService.RemoveMeeting(CurrentUser, meetingId));
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }
    }
}
