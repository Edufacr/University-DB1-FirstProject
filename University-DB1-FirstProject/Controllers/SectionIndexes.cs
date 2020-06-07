using Microsoft.AspNetCore.Mvc;

namespace University_DB1_FirstProject.Controllers
{
    public class SectionIndexes : Controller
    {
        // GET
        public IActionResult PropertiesIndex()
        {
            return View();
        }
    }
}