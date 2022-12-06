using Backend.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IDepartmentService
    {
        Task<bool> CreateDepartment(CreateDepartmentModel model, int ownerId);

        Task<bool> RemoveDepartment(int departmentId, int userId);
    }
}
