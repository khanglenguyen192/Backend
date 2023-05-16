using Backend.Common;
using Backend.Common.Models.Common;
using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public interface IOverTimeRepository : IBaseRepository<OverTime>
    {
        PagingResponseModel<OverTimeResponeModel> SearchOverTime(SearchOverTimeModel searchModel);
    }
}
