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
            Console.WriteLine(pPropertyNumber);
            ViewData["PNum"] = pPropertyNumber;
            PropertyDisplayModel property = new PropertyDisplayModel {PropertyNumber = pPropertyNumber};
            List<UserDisplayModel> list = _userController.ExecuteGetUsersOfProperty(property);
            return View(list);
        }
        public IActionResult AllProperties()
        {
            List<PropertyDisplayModel> list = new List<PropertyDisplayModel>();
            return View(list);
        }
        public IActionResult InsertProperty(int pPropertyNumber,string pAddress, float pValue)
        {
            PropertyRegisterModel property = new PropertyRegisterModel()
            {
                PropertyNumber = pPropertyNumber, Address = pAddress, Value = pValue
            };
            _propertyController.ExecuteInsertProperty(property);
            return View("Accomplished");
        }
        public IActionResult UpdateProperty(int pPropertyNumber,string pAddress, float pValue, int pNewPropertyNumber)
        {
            return View("Accomplished");
        }
        public IActionResult DeleteProperty(int pPropertyNumber)
        {
            PropertyDisplayModel property = new PropertyDisplayModel {PropertyNumber = pPropertyNumber};
            Console.WriteLine(pPropertyNumber);
            return View("Accomplished");
        }
    }
}