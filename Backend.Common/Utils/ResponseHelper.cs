using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common
{
    public static class ResponseUtil
    {
        public static ResponseModel GetOKResult(object result)
        {
            return new ResponseModel
            {
                Status = HttpStatusCode.OK,
                IsSuccess = true,
                Payload = result,
                Error = null
            };
        }

        public static ResponseModel GetServerErrorResult(string message = "")
        {
            return GetErrorResult(HttpStatusCode.InternalServerError, ErrorMessageCode.SERVER_ERROR, message);
        }

        public static ResponseModel GetBadRequestResult(string message = "")
        {
            return GetErrorResult(HttpStatusCode.BadRequest, ErrorMessageCode.BAD_REQUEST, message);
        }
    
        public static ResponseModel GetErrorResult(HttpStatusCode statusCode, string errorCode, string message = "", object data = null)
        {
            return new ResponseModel
            {
                Status = statusCode,
                IsSuccess = false,
                Payload = null,
                Error = new ErrorModel
                {
                    ErrorCode = errorCode,
                    Message = message,
                }
            };
        }
    }
}
