using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common
{
    public class PagingModel
    {
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 50;
    }
}
