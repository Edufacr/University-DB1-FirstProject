using System;
using System.Data.SqlClient;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace University_DB1_FirstProject.Controllers
{
    public class LogIn : Controller
    {
        private readonly UserController _userController = UserController.getInstance();
        
        // GET
        public IActionResult Index(string pUsername,string pPassword)
        {
            if (pUsername != null && pPassword != null)
            {
                if (_userController.ExecuteValidatePassword(pUsername, pPassword))
                {
                    Console.WriteLine(pUsername);
                    Console.WriteLine(pPassword);
                    return Redirect("Home/Index");
                }
            }
            return View();
        }
    }
}