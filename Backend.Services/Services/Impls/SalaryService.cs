using Backend.Common;
using Backend.Entities;
using Backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Backend.Entities.EnumUtil;

namespace Backend.Service
{
    public class SalaryService : ISalaryService
    {
        public List<SalaryModel> GetSalaries(int currentUserId, List<int> listUserId, DateTime currentTime)
        {
            var result = new List<SalaryModel>();
            return result;
        }
    }
}
