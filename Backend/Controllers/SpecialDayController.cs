using Backend.Common;
using Backend.DBContext;
using Backend.Entities;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/specialday")]
    [ApiController]
    public class SpecialDayController : BaseController
    {
        private readonly ISpecialDayRepository _specialDayRepository;
        public SpecialDayController(IUserService userService,
            IWebHostEnvironment webHostEnvironment,
            ILogger<BaseController> logger,
            IUserRepository userRepository,
            ISpecialDayRepository specialDayRepository)
            : base(userService, webHostEnvironment, logger, userRepository)
        {
            _specialDayRepository = specialDayRepository;
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("create")]
        [Authorize]
        public ResponseModel CreateSpecialDay([FromBody] SpecialDayModel model)
        {
            try
            {
                return ResponseUtil.GetOKResult("Success");
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpDelete]
        [Produces("application/json")]
        [Route("delete")]
        [Authorize]
        public ResponseModel CreateSpecialDay(int specialDayId)
        {
            try
            {
                return ResponseUtil.GetOKResult("Success");
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }
    }
}
