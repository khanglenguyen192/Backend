using Backend.Common;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : BaseController
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService,
                                 IUserService userService,
                                 IWebHostEnvironment webHostEnvironment,
                                 ILogger<BaseController> logger) : base(userService, webHostEnvironment, logger)
        {
            _projectService = projectService;
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("createProject")]
        [Authorize(Roles = "Administrator")]
        [Authorize]
        public ResponseModel CreateProject([FromBody] CreateProjectModel model)
        {
            try
            {
                var result = _projectService.CreateProject(model, CurrentUser.UserId);
                if (result != null)
                {
                    return ResponseUtil.GetOKResult(result);
                }

                return ResponseUtil.GetServerErrorResult(ErrorMessageCode.SERVER_ERROR);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }
    }
}
