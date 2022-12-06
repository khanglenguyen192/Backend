using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class CurrencyExchange : BaseEntity
    {
        public long Rate { get; set; }
    }
}
