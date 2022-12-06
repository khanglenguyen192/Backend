using Backend.Common.Models.User;
using Backend.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;
using System.Net;

namespace Backend.Services
{
    public class MeetingService : IMeetingService
    {
        public Task<bool> CreateMeeting(UserTokenModel userToken, CreateMeetingModel model)
        {
            return Task.FromResult(true);
        }

        public Task<bool> RemoveMeeting(UserTokenModel userToken, int meetingId)
        {
            return Task.FromResult(false);
        }
    }
}
