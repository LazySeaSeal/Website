using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiException : ApiResponse
    {
        /* this will be used for the deve error the errors that displays code error
        such as passing something null to function which will cause and error
        and we don't want the error msg to be in the form of a code !*/
        public ApiException(int statusCode, string message = null, string details=null) 
        : base(statusCode, message)
        {
            Details=details;
        }
        public string Details {get;set;}
    }
}