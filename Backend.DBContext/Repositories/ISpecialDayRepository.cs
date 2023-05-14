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
    public interface ISpecialDayRepository : IBaseRepository<SpecialDay>
    {
        PagingResponseModel<SpecialDayResponseModel> SearchSpecialDay(SearchSpecialDayModel searchModel);
    }
}
