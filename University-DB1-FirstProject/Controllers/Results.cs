using Microsoft.AspNetCore.Mvc;

namespace University_DB1_FirstProject.Controllers
{
    public class Results : Controller
    {
        // GET
        public IActionResult PropertiesUsers()
        {
            return View();
        }
    }
}