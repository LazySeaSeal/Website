using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using API.Errors;
using Infrastructue.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        public StoreContext Context { get; }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing=_context.Products.Find(42); //exemple
            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();

        }
        [HttpGet("Servererror")]
        public ActionResult GetServerError()
        {
            var thing=_context.Products.Find(42);
            var thingToReturn = thing.ToString(); // thing fiha null , donc thing.ToString() va retourner une erreur w ye9f ghadi so we fixed it ...
            
            return Ok();

        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return NotFound(new ApiResponse(400));
        }
        
        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return BadRequest();
        }



    }
}