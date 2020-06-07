using System;
using System.Collections;
using System.Data.SqlTypes;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using University_DB1_FirstProject.Models;

namespace University_DB1_FirstProject.Controllers
{
    public class Home : Controller
    {
        // GET
        public IActionResult Index(int? pOption)
        {
            return pOption switch
            {
                0 => View("Users_Index"),
                1 => View("Owners_Index"),
                2 => View("Properties_Index"),
                _ => View()
            };
        }

        public IActionResult Properties_Index(int? pOption, int? pPropertyNum, string? pAddress, SqlMoney? pValue,
            int? pNewPropertyNumber)
        {
            Console.WriteLine(pOption);
            return pOption switch
            {
                0 => Redirect("Results/PropertiesUsers?pPropertyNum=PropertyNum"),
                1 => Redirect("Results/AllProperties"),
                2 => Redirect("Results/InsertProperty?pPropertyNum=pPropertyNum&pAddress=pAddress&pValue=pValue"),
                3 => Redirect("Results/DeleteProperty?pPropertyNum=pPropertyNum"),
                4 => Redirect(
                    "Results/UpdateProperty?pPropertyNum=pPropertyNum&pAddress=pAddress&pValue=pValue&pNewPropertyNumber"),
                _ => View()
            };
        }

        public IActionResult Owners_Index(int? pOption, int? pPropertyNum, string? pAddress, SqlMoney? pValue,
            int? pNewPropertyNumber)
        {
            Console.WriteLine(pOption);
            return pOption switch
            {
                0 => Redirect("Results/PropertiesUsers?pPropertyNum=PropertyNum"),
                1 => Redirect("Results/AllProperties"),
                2 => Redirect("Results/InsertProperty?pPropertyNum=pPropertyNum&pAddress=pAddress&pValue=pValue"),
                3 => Redirect("Results/DeleteProperty?pPropertyNum=pPropertyNum"),
                4 => Redirect(
                    "Results/UpdateProperty?pPropertyNum=pPropertyNum&pAddress=pAddress&pValue=pValue&pNewPropertyNumber"),
                _ => View()
            };
        }

        public IActionResult Users_Index(int? pOption, int? pPropertyNum, string? pAddress, SqlMoney? pValue,
            int? pNewPropertyNumber)
        {
            Console.WriteLine(pOption);
            return pOption switch
            {
                0 => Redirect("Results/PropertiesUsers?pPropertyNum=PropertyNum"),
                1 => Redirect("Results/AllProperties"),
                2 => Redirect("Results/InsertProperty?pPropertyNum=pPropertyNum&pAddress=pAddress&pValue=pValue"),
                3 => Redirect("Results/DeleteProperty?pPropertyNum=pPropertyNum"),
                4 => Redirect(
                    "Results/UpdateProperty?pPropertyNum=pPropertyNum&pAddress=pAddress&pValue=pValue&pNewPropertyNumber"),
                _ => View()
            };
        }
    }
}