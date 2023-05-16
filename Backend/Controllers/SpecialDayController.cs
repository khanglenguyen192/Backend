using Backend.Common;
using Backend.Common.Models.Common;
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
            IJwtHandler jwtHandler,
            IUserRepository userRepository,
            ISpecialDayRepository specialDayRepository)
            : base(userService, webHostEnvironment, logger, jwtHandler, userRepository)
        {
            _specialDayRepository = specialDayRepository;
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
                        specialDay.DayOffStatus = EnumUtil.DayOffStatus.Waiting;
                        var check = _specialDayRepository.FirstOrDefault(d => d.UserId == specialDay.UserId && d.DateTime == specialDay.DateTime);
                        if (check != null)
                        {
                            _specialDayRepository.Delete(check);
                        }
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
        [Route("get-dayoff-emp")]
        [Authorize]
        public ResponseModel GetDayOffEmp(int userId, int type)
        {
            try
            {
                var user = _userRepository.FirstOrDefault(u => u.Id == userId && !u.IsDeactivate);
                if (user == null)
                    return ResponseUtil.GetBadRequestResult(ErrorMessageCode.USER_NOT_FOUND);

                var listDays = _specialDayRepository.GetAll(d => d.UserId == userId && d.Type == (EnumUtil.SpecialDayType)type)
                                    .OrderByDescending(x => x.Created);

                DayOffResponseModel response = new DayOffResponseModel();
                response.DayOffs = new List<DayOffModel>();

                if (listDays != null)
                {
                    foreach (var day in listDays)
                    {
                        var specialDays = _mapper.Map<SpecialDay, DayOffModel>(day);
                        response.DayOffs.Add(specialDays);
                    }
                }

                if (response.DayOffs.Any())
                    return ResponseUtil.GetOKResult(response.DayOffs);

                return ResponseUtil.GetOKResult(null);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("get-approve-dayoff")]
        [Authorize]
        public ResponseModel GetApproveDayOffEmp(int userId)
        {
            try
            {
                var user = _userRepository.FirstOrDefault(u => u.Id == userId && !u.IsDeactivate);
                if (user == null)
                    return ResponseUtil.GetBadRequestResult(ErrorMessageCode.USER_NOT_FOUND);

                var listDays = _specialDayRepository.GetAll(d => d.UserId == userId &&
                                                            d.Type == EnumUtil.SpecialDayType.DayOff &&
                                                            d.DayOffStatus == EnumUtil.DayOffStatus.Approve);

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

        [HttpPut]
        [Produces("application/json")]
        [Route("handle-request")]
        [Authorize]
        public ResponseModel HandleRequest(HandleRequestModel requestModel)
        {
            try
            {
                SpecialDay request = _specialDayRepository.FirstOrDefault(d => d.Id == requestModel.ID);
                var res = 0;

                if (request != null)
                {
                    request.DayOffStatus = (EnumUtil.DayOffStatus)requestModel.DayOffStatus;
                    res = _specialDayRepository.Update(request);
                }

                if (res != 0)
                    return ResponseUtil.GetOKResult(request);

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
                var dayoff = _specialDayRepository.FirstOrDefault(d => d.Id == specialDayId && d.DayOffStatus == EnumUtil.DayOffStatus.Waiting);
                if (dayoff == null)
                    return ResponseUtil.GetBadRequestResult(ErrorMessageCode.CAN_NOT_DAYOFF);
                _specialDayRepository.Delete(dayoff);
                return ResponseUtil.GetOKResult(dayoff);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("search")]
        [Authorize]
        public ResponseModel SearchSpecialDay(SearchSpecialDayModel searchModel)
        {
            try
            {
                var queryResult = _specialDayRepository.SearchSpecialDay(searchModel);

                return ResponseUtil.GetOKResult(queryResult);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }
    }
}
