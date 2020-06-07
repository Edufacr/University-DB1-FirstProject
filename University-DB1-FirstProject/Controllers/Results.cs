using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using University_DB1_FirstProject.Models;

namespace University_DB1_FirstProject.Controllers
{
    public class Results : Controller
    {
        private readonly PropertyController _propertyController = PropertyController.getInstance();
        private readonly UserController _userController = UserController.getInstance();
        private readonly OwnerController _ownerController = OwnerController.getInstance();
        // GET
        public IActionResult PropertiesUsers(int pPropertyNumber)
        {
            ViewData["Id"] = pPropertyNumber;
            PropertyDisplayModel property = new PropertyDisplayModel {PropertyNumber = pPropertyNumber};
            List<UserDisplayModel> list = _userController.ExecuteGetUsersOfProperty(property);
            return View(list);
        }
        public IActionResult PropertyInfo(int pPropertyNumber)
        {
            ViewData["Id"] = pPropertyNumber;
            PropertyDisplayModel property = new PropertyDisplayModel(){PropertyNumber = pPropertyNumber};
            List<PropertyDisplayModel> list = _propertyController.ExecuteGetPropertyInfoByPropertyNumber(property);
            return View(list.First());
        }
        public IActionResult AllProperties()
        {
            List<PropertyDisplayModel> list = _propertyController.ExecuteGetActiveProperties();
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
            PropertyRegisterModel newValues = new PropertyRegisterModel()
            {
                PropertyNumber = pNewPropertyNumber, Address = pAddress, Value = pValue
            };
            PropertyDisplayModel original = new PropertyDisplayModel()
            {
                PropertyNumber = pPropertyNumber
            };
            _propertyController.ExecuteUpdateProperty(original, newValues);
            return View("Accomplished");
        }
        public IActionResult DeleteProperty(int pPropertyNumber)
        {
            PropertyDisplayModel property = new PropertyDisplayModel {PropertyNumber = pPropertyNumber};
            _propertyController.ExecuteDeleteProperty(property);
            return View("Accomplished");
        }
        
        //Owners
        public IActionResult OwnerProperties(string pDocValue)
        {
            ViewData["Id"] = pDocValue;
            return View(_propertyController.ExecuteGetPropertiesOfOwner(new OwnerDisplayModel{DocValue = pDocValue}));
        }
        public IActionResult AllOwners()
        {
            return View(_ownerController.ExcecuteGetActiveOwners());
        }

        public IActionResult OwnerInfo(string pDocValue)
        {
            ViewData["Id"] = pDocValue;
            _ownerController.ExcecuteGetOwnersByDocValue(new OwnerDisplayModel{DocValue = pDocValue});
            return View();
        }
        public IActionResult OwnerInfoByName(string pName)
        {
            ViewData["Id"] = pName;
            return View("OwnerInfo");
        }
        public IActionResult InsertOwner(string pDocValue,int pDocTypeId, string pName)
        {
            _ownerController.ExecuteInsertOwner(new OwnerRegisterModel
                {DocValue = pDocValue, DocTypeId = pDocTypeId, Name = pName});
            return View("Accomplished");
        }
        public IActionResult UpdateOwner(string pDocValue,int pDocTypeId, string pName, string pNewDocValue)
        {
            _ownerController.ExecuteUpdateOwner(new OwnerDisplayModel {DocValue = pDocValue},
                new OwnerRegisterModel {DocValue = pNewDocValue, DocTypeId = pDocTypeId, Name = pName});
            return View("Accomplished");
        }
        public IActionResult DeleteOwner(string pDocValue)
        {
            _ownerController.ExecuteDeleteOwner(new OwnerDisplayModel {DocValue = pDocValue});
            return View("Accomplished");
        }
        
        //Users  ARREGLAR PARAMETROS
        public IActionResult UserProperties(string pName)
        {
            ViewData["Id"] = pName;
            return View(_propertyController.ExecuteGetPropertiesOfUser(new UserDisplayModel{Name = pName}));
        }
        public IActionResult AllUsers()
        {
            return View(_userController.ExecuteGetActiveUsers());
        }

        public IActionResult UserInfo(string pName)
        {
            ViewData["Id"] = pName;
            return View(_userController.ExecuteGetPassword(new UserDisplayModel{Name = pName}));
        }
        public IActionResult InsertUser(string pName,string pPassword,int pIsAdmin)
        {
            _userController.ExecuteInsertUser(new UserRegisterModel
                {Name = pName, Password = pPassword, UserType = pIsAdmin});
            return View("Accomplished");
        }
        public IActionResult UpdateUser(string pName,string pPassword,int pIsAdmin, string pNewName)
        {
            UserDisplayModel original = new UserDisplayModel {Name = pName};
            _userController.ExecuteUpdateUser(original,
                new UserRegisterModel
                    {Name = pNewName, UserType = pIsAdmin, Password = pPassword});
            return View("Accomplished");
        }
        public IActionResult DeleteUser(string pName)
        {
            _userController.ExecuteDeleteUser(new UserDisplayModel {Name = pName});
            return View("Accomplished");
        }
    }
}