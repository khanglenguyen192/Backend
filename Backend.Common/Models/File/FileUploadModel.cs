using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common
{
    public class FileUploadModel
    {
        public IList<IFormFile>? Files { get; set; }
    }
}
