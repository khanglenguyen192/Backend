using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class HardCode : BaseEntity
    {
        public string ParentId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
