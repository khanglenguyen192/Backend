﻿using Backend.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface ISalaryService
    {
        List<SalaryModel> GetSalaries(int currentUserId, List<int> listUserId, DateTime currentTime);
    }
}