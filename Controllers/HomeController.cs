using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace OrbitGraphQL.Controllers
{
    public class HomeController : Controller
    {
        // 
        // GET: /HelloWorld/
        [Route("")]
        [Route("Home")]
        public IActionResult Index()
        {
            return Ok("Orbit GraphQL");
        }
    }
}
