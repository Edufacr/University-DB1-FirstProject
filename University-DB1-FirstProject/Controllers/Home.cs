using System;
using System.Collections;
using System.Data.SqlTypes;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
                2 => RedirectToAction("Properties_Index"),
                _ => View()
            };
        }

        public IActionResult Properties_Index(int? option, int? propertyNumber, float ?value,
            int? newPropertyNumber, string address = "default")
        {
            Console.WriteLine(propertyNumber);
            return option switch
            {
                0 => RedirectToAction("AllProperties","Results"),
                1 => RedirectToAction("PropertiesUsers","Results",new RouteValueDictionary(new {controller = "Results",action = "PropertiesUsers",pPropertyNumber = propertyNumber })),
                2 => RedirectToAction("InsertProperty","Results",new RouteValueDictionary{{"pPropertyNumber",propertyNumber},{"pAddress",address},{"pValue",value}}),
                3 => RedirectToAction("DeleteProperty","Results",new RouteValueDictionary(new {controller = "Results",action = "PropertiesUsers",pPropertyNumber = propertyNumber })),
                4 => RedirectToAction("InsertProperty","Results",new RouteValueDictionary{{"pPropertyNumber",propertyNumber},{"pAddress",address},{"pValue",value},{"pNewPropertyNumber",newPropertyNumber}}),
                _ => View()
            };
        }

        public IActionResult Owners_Index(int? pOption, int? pPropertyNum, string? pAddress, float? pValue,
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

        public IActionResult Users_Index(int? pOption, int? pPropertyNum, string? pAddress, float? pValue,
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