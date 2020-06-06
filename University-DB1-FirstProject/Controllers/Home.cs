using Microsoft.AspNetCore.Mvc;

namespace University_DB1_FirstProject.Controllers
{
    public class Home : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}