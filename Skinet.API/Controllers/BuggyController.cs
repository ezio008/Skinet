using Microsoft.AspNetCore.Mvc;
using Skinet.API.Errors;
using Skinet.Infrastructure;

namespace Skinet.API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly ApplicationDbContext _dbContext;

        public BuggyController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _dbContext.Products.Find(42);

            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _dbContext.Products.Find(42);

            var thingToReturn = thing.ToString();

            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return BadRequest(new ApiResponse(400));
        }
    }
}
