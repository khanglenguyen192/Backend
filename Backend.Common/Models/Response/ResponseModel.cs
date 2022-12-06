using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common
{
    public class ResponseModel
    {
        public HttpStatusCode Status { get; set; }

        public ErrorModel Error { get; set; }

        public bool IsSuccess { get; set; } = false;

        public object Data { get; set; }
    }
}
