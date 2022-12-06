using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class FilePolicy : BaseEntity
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public bool IsDirectory { get; set; }
        public int ParentId { get; set; }
    }
}
