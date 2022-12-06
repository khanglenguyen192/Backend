using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class RateOvertime : BaseEntity
    {
        public DateTime DateTime { get; set; }

        public float Rate { get; set; }
    }
}
