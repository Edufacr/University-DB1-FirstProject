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
            ViewData["Id"] = pPropertyNumber;
            PropertyDisplayModel property = new PropertyDisplayModel {PropertyNumber = pPropertyNumber};
            List<UserDisplayModel> list = _userController.ExecuteGetUsersOfProperty(property);
            return View(list);
        }
        public IActionResult PropertyInfo(int pPropertyNumber)
        {
            return View();
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
        
        //Owners
        public IActionResult OwnerProperties(string pDocValue)
        {
            ViewData["Id"] = pDocValue;
            return View();
        }
        public IActionResult AllOwners()
        {
            return View();
        }

        public IActionResult OwnerInfo(string pDocValue)
        {
            return View();
        }
        public IActionResult InsertOwner(string pDocValue,int pDocTypeId, string pName)
        {
            return View("Accomplished");
        }
        public IActionResult UpdateOwner(string pDocValue,int pDocTypeId, string pName, string pNewDocValue)
        {
            return View("Accomplished");
        }
        public IActionResult DeleteOwner(string pDocValue)
        {
            return View("Accomplished");
        }
        
        //Users  ARREGLAR PARAMETROS
        public IActionResult UserProperties(string pDocValue)
        {
            ViewData["Id"] = pDocValue;
            return View();
        }
        public IActionResult AllUsers()
        {
            return View();
        }

        public IActionResult UserInfo(string pDocValue)
        {
            return View();
        }
        public IActionResult InsertUser(string pDocValue,int pDocTypeId, string pName)
        {
            return View("Accomplished");
        }
        public IActionResult UpdateUser(string pDocValue,int pDocTypeId, string pName, string pNewDocValue)
        {
            return View("Accomplished");
        }
        public IActionResult DeleteUser(string pDocValue)
        {
            return View("Accomplished");
        }
    }
}