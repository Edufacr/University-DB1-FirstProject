﻿using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace University_DB1_FirstProject.Controllers
{
    public class LogIn : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}