using System;
using System.Data.SqlClient;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace University_DB1_FirstProject.Controllers
{
    public class LogIn : Controller
    {
        private UserController UserController = UserController.getInstance();
        
        // GET
        public IActionResult Index(string pUsername,string pPassword)
        {
            if (pUsername != null && pPassword != null)
            {
                if (UserController.ExecuteValidatePassword(pUsername, pPassword))
                {
                    
                    Console.WriteLine(pUsername);
                    Console.WriteLine(pPassword);
                    
                return Redirect("Home/Properties_Querry");
                }
            }
       
            return View();
        }
    }
}