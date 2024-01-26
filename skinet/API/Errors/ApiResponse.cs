using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        
        public ApiResponse(int statusCode,string message=null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);  // code1 ?? code22 means '??' if code1 is null then code2
        }

       
        public int StatusCode { get; set; }
        public string Message { get; set; }
        
        
         private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch //switch normal mais sans case fancy switch hh
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found , it was not",
                500 => "Errors !!!!!!!!!!!!!!!!!!",
                _=> null //_ for default
            };
        }
    }
}