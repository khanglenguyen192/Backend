using Backend.Common;
using Backend.Common.Models.Department;
using Backend.DBContext;
using Backend.Entities;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Backend.Entities.EnumUtil;

namespace Backend.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDepartmentMapRepository _departmentMapRepository;
        private readonly IDepartmentUserMapRepository _departmentUserMapRepository;
        private readonly IRoleRepository _roleRepository;

        public DepartmentController(IUserService userService,
                                    IWebHostEnvironment webHostEnvironment,
                                    ILogger<BaseController> logger,
                                    IJwtHandler jwtHandler,
                                    IUserRepository userRepository,
                                    IDepartmentRepository departmentRepository,
                                    IDepartmentMapRepository departmentMapRepository,
                                    IDepartmentUserMapRepository departmentUserMapRepository,
                                    IRoleRepository roleRepository) 
            : base(userService, webHostEnvironment, logger, jwtHandler, userRepository)
        {
            _departmentRepository = departmentRepository;
            _departmentMapRepository = departmentMapRepository;
            _departmentUserMapRepository = departmentUserMapRepository;
            _roleRepository = roleRepository;
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("create-department")]
        //[Authorize(Roles = "Administrator")]
        [Authorize]
        public ResponseModel CreateDepartment([FromBody] CreateDepartmentModel model)
        {
            try
            {
                Department department = _mapper.Map<CreateDepartmentModel, Department>(model);

                Department parentDepartment = null;
                if (model.ParentId != null)
                {
                    parentDepartment = _departmentRepository.FirstOrDefault(d => d.Id == model.ParentId && !d.IsDeactivate);

                    if (parentDepartment == null)
                        return ResponseUtil.GetBadRequestResult("Parent department not exist");
                }

                department.OwnerId = 1; //Default: Assign to root user

                department.IsRoot = parentDepartment == null;

                _departmentRepository.Insert(department);

                if (parentDepartment != null)
                {
                    DepartmentMap departmentMap = new DepartmentMap();
                    departmentMap.DepartmentId = department.Id;
                    departmentMap.ParentDepartmentId = parentDepartment.Id;
                    _departmentMapRepository.Insert(departmentMap);
                }

                if (model.Users != null)
                {
                    foreach (var userModel in model.Users)
                    {
                        var user = _userRepository.FirstOrDefault(u => u.Id == userModel.Id && !u.IsDeactivate);
                        if (user != null)
                        {
                            DepartmentUserMap departmentUserMap = new DepartmentUserMap();
                            departmentUserMap.UserId = userModel.Id;
                            departmentUserMap.DepartmentId = department.Id;
                            Role role = _roleRepository.FirstOrDefault(r => r.Id == userModel.RoleId && !r.IsDeactivate);
                            departmentUserMap.RoleId = DepartmentRole.Employee;

                            _departmentUserMapRepository.Insert(departmentUserMap);
                        }
                    }
                }

                return ResponseUtil.GetOKResult(department);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("get-by-owner")]
        [Authorize]
        public ResponseModel GetDepartments(int userId)
        {
            try
            {
                return ResponseUtil.GetOKResult(_departmentRepository.GetAll(d => d.OwnerId == userId && !d.IsDeactivate));
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("get-root-deparments")]
        [Authorize]
        public ResponseModel GetRootDepartments([FromHeader] string authorization)
        {
            try
            {
                return ResponseUtil.GetOKResult(_departmentRepository.GetRootDepartments());
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpDelete]
        [Produces("application/json")]
        [Route("remove-departments")]
        //[Authorize(Roles = "Administrator")]
        public ResponseModel RemoveDepartment(int departmentId)
        {
            try
            {
                var department = _departmentRepository.FirstOrDefault(d => d.Id == departmentId);
                if (department == null)
                    return ResponseUtil.GetBadRequestResult(ErrorMessageCode.DEPARTMENT_NOT_FOUND);

                department.IsDeactivate = true;
                _departmentRepository.Update(department);

                return ResponseUtil.GetOKResult("OK");
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("add-department-users")]
        //[Authorize(Roles = "Administrator")]
        [Authorize]
        public ResponseModel AddUsersToDepartment([FromBody] AddDepartmentUserModel model)
        {
            try
            {
                var department = _departmentRepository.FirstOrDefault(d => d.Id == model.DepartmentId);
                if (department == null)
                    return ResponseUtil.GetBadRequestResult(ErrorMessageCode.DEPARTMENT_NOT_FOUND);

                if (model.Users != null )
                {
                    foreach (var userModel in model.Users)
                    {
                        var user = _userRepository.FirstOrDefault(u => u.Id == userModel.Id && !u.IsDeactivate);
                        if (user != null)
                        {
                            DepartmentUserMap departmentUserMap = new DepartmentUserMap();
                            departmentUserMap.UserId = userModel.Id;
                            departmentUserMap.DepartmentId = model.DepartmentId;
                            departmentUserMap.RoleId = DepartmentRole.Employee;

                            _departmentUserMapRepository.Insert(departmentUserMap);
                        }
                    }
                }
                
                return ResponseUtil.GetOKResult("SUCCESS");
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("get-department-users")]
        [Authorize]
        public ResponseModel GetDepartmentUsers(int departmentId)
        {
            try
            {
                var department = _departmentRepository.FirstOrDefault(d => d.Id == departmentId);
                if (department == null)
                    return ResponseUtil.GetBadRequestResult(ErrorMessageCode.DEPARTMENT_NOT_FOUND);

                var departmentUsers = _departmentUserMapRepository.GetAll(d => d.DepartmentId == departmentId && !d.IsDeactivate);

                List<UserInfoModel> response = new List<UserInfoModel>();

                if (departmentUsers != null)
                {
                    foreach (var departmentUser in departmentUsers)
                    {
                        var user = _userRepository.FirstOrDefault(p => p.Id == departmentUser.UserId && !p.IsDeactivate);
                        if (user != null)
                        {
                            UserInfoModel userInfoModel = _mapper.Map<User, UserInfoModel>(user);
                            userInfoModel.DepartmentRole = (int)departmentUser.RoleId;
                            if (departmentUser.RoleId == DepartmentRole.Manager)
                            {
                                response.Insert(0, userInfoModel);
                            }
                            else
                            {
                                response.Add(userInfoModel);
                            }
                        }
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

        [HttpGet]
        [Produces("application/json")]
        [Route("get-department")]
        [Authorize]
        public ResponseModel GetDepartment(int departmentId)
        {
            try
            {
                var department = _departmentRepository.FirstOrDefault(d => d.Id == departmentId);
                if (department == null)
                    return ResponseUtil.GetBadRequestResult(ErrorMessageCode.DEPARTMENT_NOT_FOUND);

                return ResponseUtil.GetOKResult(department);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("get-for-employee")]
        [Authorize]
        public ResponseModel GetDepartmentsForEmployee(int employeeId)
        {
            try
            {
                var departmentIds = _departmentUserMapRepository.GetAll(d => d.UserId == employeeId && !d.IsDeactivate)?.Select(p => p.DepartmentId).ToList();

                if (departmentIds != null)
                {
                    var departments = _departmentRepository.GetAll(d => departmentIds.Contains(d.Id) && !d.IsDeactivate);
                    return ResponseUtil.GetOKResult(departments);
                }

                return ResponseUtil.GetOKResult(null);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("get-children")]
        [Authorize]
        public ResponseModel GetChildren(int departmentId)
        {
            try
            {
                var department = _departmentRepository.FirstOrDefault(d => d.Id == departmentId);
                if (department == null)
                    return ResponseUtil.GetBadRequestResult(ErrorMessageCode.DEPARTMENT_NOT_FOUND);

                var childDepartmentIds = _departmentMapRepository.GetAll(d => d.ParentDepartmentId == departmentId && !d.IsDeactivate).Select(p => p.DepartmentId);

                if (childDepartmentIds != null)
                {
                    return ResponseUtil.GetOKResult(_departmentRepository.GetAll(d => childDepartmentIds.Contains(d.Id) && !d.IsDeactivate));
                }

                return ResponseUtil.GetOKResult(null);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("get-users-to-add")]
        [Authorize]
        public ResponseModel GetUsersToAdd(int departmentId, [FromHeader] string authorization)
        {
            try
            {
                var department = _departmentRepository.FirstOrDefault(d => d.Id == departmentId);
                if (department == null)
                    return ResponseUtil.GetBadRequestResult(ErrorMessageCode.DEPARTMENT_NOT_FOUND);

                var usersToAdd = _userRepository.GetUserToAddDepartment(departmentId);

                List<UserInfoModel> response = new List<UserInfoModel>();

                if (usersToAdd != null)
                {
                    foreach (var user in usersToAdd)
                    {
                        if (user != null)
                        {
                            UserInfoModel userInfoModel = _mapper.Map<User, UserInfoModel>(user);
                            response.Add(userInfoModel);
                        }
                    }
                }

                return ResponseUtil.GetOKResult(response);
            }
            catch (Exception ex)
            {
                return ResponseUtil.GetServerErrorResult(ex.ToString());
            }
        }
    }
}
