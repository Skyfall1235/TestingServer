using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestingServer2.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // This defines the base route for the controller.
    public class UsersController : ControllerBase
    {
        // GET: api/users
        [HttpGet]
        public IEnumerable<string> Get()
        {
            // Instead of returning a view, you return data.
            return new string[] { "value1", "value2" };
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            return "value";
        }

        // 
        /// <summary>
        /// POST: api/users
        /// </summary>
        /// <param name="value">the value</param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            // You would handle the data here.
        }
    }
}
