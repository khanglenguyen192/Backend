using Backend.Common.Models.User;
using Backend.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IMeetingService
    {
        Task<bool> CreateMeeting(UserTokenModel userToken, CreateMeetingModel model);
        Task<bool> RemoveMeeting(UserTokenModel userToken, int meetingId);
    }
}
