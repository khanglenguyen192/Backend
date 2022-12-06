using Backend.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class ProjectService : IProjectService
    {
        public ProjectRespondModel CreateProject(CreateProjectModel model, int ownerId)
        {
            return new ProjectRespondModel();
        }
    }
}
