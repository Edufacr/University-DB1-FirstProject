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
            int? newPropertyNumber, string? address)
        {
            Console.WriteLine(propertyNumber);
            return option switch
            {
                0 => RedirectToAction("AllProperties","Results"),
                1 => RedirectToAction("PropertyInfo","Results",new RouteValueDictionary{{"pPropertyNumber",propertyNumber}}),
                2 => RedirectToAction("PropertiesUsers","Results",new RouteValueDictionary(new {controller = "Results",action = "PropertiesUsers",pPropertyNumber = propertyNumber })),
                3 => RedirectToAction("InsertProperty","Results",new RouteValueDictionary{{"pPropertyNumber",propertyNumber},{"pAddress",address},{"pValue",value}}),
                4 => RedirectToAction("DeleteProperty","Results",new RouteValueDictionary(new {controller = "Results",action = "PropertiesUsers",pPropertyNumber = propertyNumber })),
                5 => RedirectToAction("InsertProperty","Results",new RouteValueDictionary{{"pPropertyNumber",propertyNumber},{"pAddress",address},{"pValue",value},{"pNewPropertyNumber",newPropertyNumber}}),
                _ => View()
            };
        }

        public IActionResult Owners_Index(int? option, int? docType, string? docValue, string? name, string? newDocValue)
        {
            return option switch
            {
                0 => RedirectToAction("AllOwners","Results"),
                1 => RedirectToAction("OwnerInfo","Results",new RouteValueDictionary{{"pDocValue",docValue}}),
                2 => RedirectToAction("OwnerProperties","Results",new RouteValueDictionary{{"pDocValue",docValue}}),
                3 => RedirectToAction("InsertOwner","Results",new RouteValueDictionary{{"pDocValue",docValue},{"pDocType",docType},{"pName",name}}),
                4 => RedirectToAction("DeleteOwner","Results",new RouteValueDictionary{{"pDocValue",docValue}}),
                5 => RedirectToAction("InsertOwner","Results",new RouteValueDictionary{{"pDocValue",docValue},{"pDocType",docType},{"pName",name},{"pNewDocValue",newDocValue}}),
                _ => View()
            };
        }

        public IActionResult Users_Index(int? option, string? name,bool? isAdmin,string? password,string? newName)
        {
            return option switch
            {
                0 => RedirectToAction("AllUsers","Results"),
                1 => RedirectToAction("UserInfo","Results",new RouteValueDictionary{{"pName",name}}),
                2 => RedirectToAction("UserProperties","Results",new RouteValueDictionary{{"pName",name}}),
                3 => RedirectToAction("InsertUser","Results",new RouteValueDictionary{{"pName",name},{"pIsAdmin",isAdmin},{"pPassword",password}}),
                4 => RedirectToAction("DeleteUser","Results",new RouteValueDictionary{{"pName",name}}),
                5 => RedirectToAction("InsertUser","Results",new RouteValueDictionary{{"pName",name},{"pIsAdmin",isAdmin},{"pPassword",password},{"pNewName",newName}}),
                _ => View()
            };
        }
    }
}