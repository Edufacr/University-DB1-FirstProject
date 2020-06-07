using System;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace University_DB1_FirstProject.Controllers
{
    public class LogIn : Controller
    {
        // GET
        public IActionResult Index(string pUsername,string pPassword)
        {
            if (pUsername == "h")
            {
                return Redirect("Home/Properties_Querry");
            }
            return View();
        }
    }
}