using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        /*we're treating errors for bad type: the client puts a name in a place where it should be an int ...
        so this will handle the forum errors + url/.../{id} where id gotta be an int
        but the client actaully write url/.../five so this will generate an error and 
        here we will treat tit*/
        public ApiValidationErrorResponse() : base(400) 
        {
        }
        public IEnumerable<string> Errors {get;set;}
    }
}