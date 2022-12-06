using Backend.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class DepartmentService : IDepartmentService
    {
        public Task<bool> CreateDepartment(CreateDepartmentModel model, int ownerId)
        {
            return Task.FromResult(true);
        }

        public Task<bool> RemoveDepartment(int departmentId, int userId)
        {
            return Task.FromResult(true);
        }
    }
}
