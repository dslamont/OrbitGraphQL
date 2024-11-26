using Microsoft.AspNetCore.Mvc;

namespace OrbitGraphQL.Controllers
{
    public class HomeController : Controller
    {
        // 
        // GET: /HelloWorld/
        public string Index()
        {
            return "GraphQL Test";
        }
    }
}
