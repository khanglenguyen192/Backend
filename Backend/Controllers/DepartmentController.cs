using Backend.Common;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService,
                                    IUserService userService,
                                    IWebHostEnvironment webHostEnvironment,
                                    ILogger<BaseController> logger) : base(userService, webHostEnvironment, logger)
        {
            _departmentService = departmentService;
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("createDepartment")]
        [Authorize(Roles = "Administrator")]
        [Authorize]
        public ResponseModel CreateDepartment([FromBody] CreateDepartmentModel model)
        {
            try
            {
                var result = _departmentService.CreateDepartment(model, CurrentUser.UserId);
                if (result != null)
                {
                    return GetOKResult(result);
                }

                return GetServerErrorResult(ErrorMessageCode.CAN_NOT_CREATE_DEPARTMENT);
            }
            catch (Exception ex)
            {
                return GetServerErrorResult(ex.ToString());
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("getDepartments")]
        [Authorize]
        public ResponseModel GetDepartments(int userId)
        {
            try
            {
                return GetOKResult(null);
            }
            catch (Exception ex)
            {
                return GetServerErrorResult(ex.ToString());
            }
        }

        [HttpDelete]
        [Produces("application/json")]
        [Route("removeDepartment")]
        [Authorize(Roles = "Administrator")]
        public ResponseModel RemoveDepartment(int departmentId)
        {
            if (departmentId == 0) return GetBadRequestResult(ErrorMessageCode.DEPARTMENT_NOT_FOUND);

            try
            {
                return GetOKResult(_departmentService.RemoveDepartment(departmentId, CurrentUser.UserId));
            }
            catch (Exception ex)
            {
                return GetServerErrorResult(ex.ToString());
            }
        }
    }
}
