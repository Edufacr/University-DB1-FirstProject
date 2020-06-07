using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc;
using University_DB1_FirstProject.Models;

namespace University_DB1_FirstProject.Controllers
{
    public class Results : Controller
    {
        private readonly PropertyController _propertyController = PropertyController.getInstance();
        private readonly UserController _userController = UserController.getInstance();
        // GET
        public IActionResult PropertiesUsers(int pPropertyNumber)
        {
            Console.WriteLine("DisplayResults");
            ViewData["PNum"] = pPropertyNumber;
            PropertyDisplayModel property = new PropertyDisplayModel {PropertyNumber = pPropertyNumber};
            List<UserDisplayModel> list = _userController.ExecuteGetUsersOfProperty(property);
            return View(list);
        }
        public IActionResult AllProperties()
        {
            Console.WriteLine("DisplayResults");
            List<PropertyDisplayModel> list = new List<PropertyDisplayModel>();
            return View(list);
        }
        public IActionResult InsertProperty(int pPropertyNumber,string pAddress, SqlMoney pValue)
        {
            PropertyRegisterModel property = new PropertyRegisterModel()
            {
                PropertyNumber = pPropertyNumber, Address = pAddress, Value = 1
            };
            _propertyController.ExecuteInsertProperty(property);
            Console.WriteLine("DisplayResults");
            return View("Accomplished");
        }
        public IActionResult UpdateProperty(int pPropertyNumber,string pAddress, SqlMoney pValue, int pNewPropertyNumber)
        {
            Console.WriteLine("DisplayResults");
            return View("Accomplished");
        }
        public IActionResult DeleteProperty(int pPropertyNumber)
        {
            Console.WriteLine("DisplayResults");
            return View("Accomplished");
        }
    }
}