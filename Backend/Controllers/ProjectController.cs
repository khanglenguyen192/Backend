using Backend.Common;
using Backend.Common.Models.Project;
using Backend.DBContext;
using Backend.Entities;
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
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectUserMapRepository _projectUserMapRepository;

        public ProjectController(IUserService userService,
                                 IWebHostEnvironment webHostEnvironment,
                                 ILogger<BaseController> logger,
                                 IUserRepository userRepository,
                                 IProjectRepository projectRepository,
                                 IProjectUserMapRepository projectUserMapRepository)
            : base(userService, webHostEnvironment, logger, userRepository)
        {
            _projectRepository = projectRepository;
            _projectUserMapRepository = projectUserMapRepository;
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("create")]
        //[Authorize(Roles = "Administrator")]
        [Authorize]
        public ResponseModel CreateProject([FromBody] CreateProjectModel model)
        {
            try
            {
                Project project = _mapper.Map<CreateProjectModel, Project>(model);
                if (model.Status == null)
                    project.Status = EnumUtil.ProjectStatus.Working;

                project.OwnerId = 1; //Owner is root user
                _projectRepository.Insert(project);

                return ResponseUtil.GetOKResult(project);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpDelete]
        [Produces("application/json")]
        [Route("remove")]
        //[Authorize(Roles = "Administrator")]
        [Authorize]
        public ResponseModel Remove([FromBody] int projectId)
        {
            try
            {
                var project = _projectRepository.FirstOrDefault(p => p.Id == projectId && !p.IsDeactivate);
                if (project == null)
                    return ResponseUtil.GetBadRequestResult("Project not found");

                project.IsDeactivate = true;
                _projectRepository.Update(project);

                var projectUsers = _projectUserMapRepository.GetAll(p => p.ProjectId == projectId && !p.IsDeactivate);

                if (projectUsers != null)
                {
                    foreach(var user in projectUsers)
                    {
                        user.IsDeactivate = true;
                        _projectUserMapRepository.Update(user);
                    }
                }

                return ResponseUtil.GetOKResult(project);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpPost]
        [Route("update")]
        //[Authorize(Roles = "Administrator")]
        [Authorize]
        public ResponseModel UpdateProject([FromBody] UpdateProjectModel model, IFormFile projectLogo)
        {
            try
            {
                Project project = _mapper.Map<UpdateProjectModel, Project>(model);
                project.ProjectLogo = FileUtils.ImageUpload(Constants.UserDataFolderName, projectLogo);
                _projectRepository.Update(project);

                return ResponseUtil.GetOKResult(project);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("add-users")]
        //[Authorize(Roles = "Administrator")]
        [Authorize]
        public ResponseModel AddProjectUsers([FromBody] AddProjectUsersModel model)
        {
            try
            {
                var project = _projectRepository.FirstOrDefault(p => p.Id == model.ProjectId && !p.IsDeactivate);

                if (project == null)
                    return ResponseUtil.GetBadRequestResult("Project not found");

                List<ProjectUserMap> users = new List<ProjectUserMap>();

                if (model.UserIds !=null)
                {
                    foreach(var userId in model.UserIds)
                    {
                        var user = _userRepository.FirstOrDefault(u => u.Id == userId && !u.IsDeactivate);
                        if (user != null)
                        {
                            var projectUserMap = _projectUserMapRepository.FirstOrDefault(p => p.ProjectId == model.ProjectId && p.UserId == userId);
                            if (projectUserMap == null)
                            {
                                ProjectUserMap projectUser = new ProjectUserMap();
                                projectUser.UserId = userId;
                                projectUser.ProjectId = model.ProjectId;
                                if (user.Id == model.LeaderId)
                                    projectUser.IsLeader = true;

                                _projectUserMapRepository.Insert(projectUser);

                                users.Add(projectUser);
                            }
                            else if (projectUserMap != null && projectUserMap.IsDeactivate)
                            {
                                projectUserMap.IsDeactivate = false;
                                _projectUserMapRepository.Update(projectUserMap);
                                users.Add(projectUserMap);
                            }
                        }
                    }
                }

                return ResponseUtil.GetOKResult(users);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("get-users")]
        //[Authorize(Roles = "Administrator")]
        [Authorize]
        public ResponseModel GetProjectUsers(int projectId)
        {
            try
            {
                var project = _projectRepository.FirstOrDefault(p => p.Id == projectId && !p.IsDeactivate);

                if (project == null)
                    return ResponseUtil.GetBadRequestResult("Project not found");

                var projectUsers = _projectUserMapRepository.GetAll(p => p.ProjectId == projectId && !p.IsDeactivate);
                var leader = projectUsers.FirstOrDefault(p => p.IsLeader && !p.IsDeactivate);
                var userIds = projectUsers.Select(p => p.UserId).ToList();

                List<UserInfoModel> response = new List<UserInfoModel>();

                foreach (var userId in userIds)
                {
                    var user = _userRepository.FirstOrDefault(p => p.Id == userId && !p.IsDeactivate);
                    if (user != null)
                    {
                        UserInfoModel userInfoModel = _mapper.Map<User, UserInfoModel>(user);
                        if (leader?.UserId == user.Id)
                            userInfoModel.IsLeader = true;
                        response.Add(userInfoModel);
                    }
                }

                if (response.Any())
                    return ResponseUtil.GetOKResult(response);

                return ResponseUtil.GetOKResult(null);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("remove-users")]
        //[Authorize(Roles = "Administrator")]
        [Authorize]
        public ResponseModel RemoveProjectUsers([FromBody] AddProjectUsersModel model)
        {
            try
            {
                var project = _projectRepository.FirstOrDefault(p => p.Id == model.ProjectId && !p.IsDeactivate);

                if (project == null)
                    return ResponseUtil.GetBadRequestResult("Project not found");

                List<ProjectUserMap> users = new List<ProjectUserMap>();

                if (model.UserIds != null)
                {
                    foreach (var userId in model.UserIds)
                    {
                        var user = _userRepository.FirstOrDefault(u => u.Id == userId && !u.IsDeactivate);
                        if (user != null)
                        {
                            var projectUserMap = _projectUserMapRepository.FirstOrDefault(p => p.ProjectId == model.ProjectId && p.UserId == userId && !p.IsDeactivate);
                            if (projectUserMap != null)
                            {
                                projectUserMap.IsDeactivate = true;
                                _projectUserMapRepository.Update(projectUserMap);
                                users.Add(projectUserMap);
                            }
                        }
                    }
                }

                return ResponseUtil.GetOKResult(users);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("update-status")]
        //[Authorize(Roles = "Administrator")]
        [Authorize]
        public ResponseModel UpdateStatus([FromBody] ProjectStatusModel model)
        {
            try
            {
                var project = _projectRepository.FirstOrDefault(p => p.Id == model.ProjectId && !p.IsDeactivate);

                if (project == null)
                    return ResponseUtil.GetBadRequestResult("Project not found");

                project.Status = model.ProjectStatus;
                _projectRepository.Update(project);

                return ResponseUtil.GetOKResult(project);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("get-by-user")]
        //[Authorize(Roles = "Administrator")]
        [Authorize]
        public ResponseModel GetByUser(int userId)
        {
            try
            {
                if (_userRepository.Exists(u => u.Id == userId && !u.IsDeactivate))
                    return ResponseUtil.GetBadRequestResult("user_not_found");

                var projectIds = _projectUserMapRepository.GetAll(p => p.UserId == userId && !p.IsDeactivate)?.Select(p => p.ProjectId);

                List<Project> projects = new List<Project>();

                if (projectIds != null)
                {
                    foreach (var projectId in projectIds)
                    {
                        var project = _projectRepository.FirstOrDefault(p => p.Id == projectId && !p.IsDeactivate);
                        if (project != null)
                            projects.Add(project);
                    }
                }

                return ResponseUtil.GetOKResult(projects);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }
    }
}
