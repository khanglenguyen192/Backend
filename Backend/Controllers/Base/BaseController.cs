using AutoMapper;
using Backend.Common;
using Backend.Common.Models.User;
using Backend.Entities;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Backend.Entities.EnumUtil;

namespace Backend.Controllers
{
    /// <summary>
    /// BaseController
    /// </summary>
    public abstract class BaseController : ControllerBase
    {
        protected readonly IWebHostEnvironment _webHostEnvironment;
        protected readonly ILogger<BaseController> _logger;
        protected readonly IUserService _userService;

        protected readonly MapperConfiguration _mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CreateDepartmentModel, Department>();
            cfg.CreateMap<CreateProjectModel, Project>();
            cfg.CreateMap<UserInfoModel, User>();
            cfg.CreateMap<User, UserInfoModel>();
        });

        protected Mapper _mapper;

        protected UserTokenModel CurrentUser { get { return GetUserIdentify(); } }

        public BaseController(IUserService userService,
            IWebHostEnvironment webHostEnvironment,
            ILogger<BaseController> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _userService = userService;
            _mapper = new Mapper(_mapperConfig);
        }

        

        protected UserTokenModel GetUserIdentify()
        {
            var userModel = new UserTokenModel();

            var identity = HttpContext.User.Identity as System.Security.Claims.ClaimsIdentity;

            if (identity == null) return null;

            userModel.UserId = Convert.ToInt32(identity.Name);

            var claim = identity.Claims.FirstOrDefault(p => p.Type.ToLower().Equals(Constants.ROLE.ToLower()));

            if (claim != null)
            {
                userModel.UserRole = (UserRole)Convert.ToInt32(claim.Value);
            }

            var user = _userService.GetUserById(userModel.UserId);

            if (user == null) return null;

            userModel.FullName = user.FullName;

            TimeZoneInfo timeZone = CommonUtils.GetLocalTimeZone(user);
            userModel.TimeZoneInfo = timeZone;

            return userModel;
        }
    }
}
