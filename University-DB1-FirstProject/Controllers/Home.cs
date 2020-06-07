using Microsoft.AspNetCore.Mvc;
using University_DB1_FirstProject.Models;

namespace University_DB1_FirstProject.Controllers
{
    public class Home : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Properties_Querry()
        {
            PropertyDisplayModel model = new PropertyDisplayModel();
            model.Address = "adress";
            model.Value = 12;
            model.PropertyNumber = 123;
            return View(model);
        }
    }
}