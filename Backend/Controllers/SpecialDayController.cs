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
        private readonly IUserRepository _userRepository;

        public SpecialDayController(IUserService userService,
            IWebHostEnvironment webHostEnvironment,
            ILogger<BaseController> logger,
            IUserRepository userRepository,
            ISpecialDayRepository specialDayRepository)
            : base(userService, webHostEnvironment, logger, userRepository)
        {
            _specialDayRepository = specialDayRepository;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("create")]
        [Authorize]
        public ResponseModel CreateSpecialDay([FromBody] SpecialDayRequestModel model)
        {
            try
            {
                IList<SpecialDay> result = new List<SpecialDay>();
                if (model.SpecialDays != null)
                {
                    foreach (var specialDayModel in model.SpecialDays)
                    {
                        SpecialDay specialDay = _mapper.Map<SpecialDayModel, SpecialDay>(specialDayModel);
                        _specialDayRepository.Insert(specialDay);
                        result.Add(specialDay);
                    }
                }

                return ResponseUtil.GetOKResult(result);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("get")]
        [Authorize]
        public ResponseModel GetSpecialDays(int userId)
        {
            try
            {
                var user = _userRepository.FirstOrDefault(u => u.Id == userId && !u.IsDeactivate);
                if (user == null)
                    return ResponseUtil.GetBadRequestResult(ErrorMessageCode.USER_NOT_FOUND);

                var listDays = _specialDayRepository.GetAll(d => d.UserId == userId);

                SpecialDayRequestModel response = new SpecialDayRequestModel();
                response.SpecialDays = new List<SpecialDayModel>();

                if (listDays != null)
                {
                    foreach (var day in listDays)
                    {
                        var specialDays = _mapper.Map<SpecialDay, SpecialDayModel>(day);
                        response.SpecialDays.Add(specialDays);
                    }
                }

                if (response.SpecialDays.Any())
                    return ResponseUtil.GetOKResult(response.SpecialDays);

                return ResponseUtil.GetOKResult(null);
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
        public ResponseModel DeleteSpecialDay(int specialDayId)
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
