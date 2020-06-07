using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using University_DB1_FirstProject.Controllers;
using University_DB1_FirstProject.Interfaces;
using University_DB1_FirstProject.Models;

namespace University_DB1_FirstProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = IConnectionStrings.CONNECTIONSTRING;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            
            UserController userController = new UserController(connection);
            LegalOwnerController legalOwnerController = new LegalOwnerController(connection);
            OwnerController ownerController = new OwnerController(connection);
            PropertyController propertyController = new PropertyController(connection);
            ChargeConceptController chargeConceptController = new ChargeConceptController(connection);

            UserDisplayModel testUser = new UserDisplayModel();
            testUser.Name = "LDiaz";
            testUser.isAdmin = false;
            
            PropertyDisplayModel testProperty = new PropertyDisplayModel();
            testProperty.Address =
                "Condominio Mar del Plata, Filial 186";
            testProperty.Value = (float)12348471.20;
            testProperty.PropertyNumber = 1176180;
            
            CCPropertyDisplayModel testCCProperty = new CCPropertyDisplayModel();
            testCCProperty.BeginDate = "2020-05-23";
            testCCProperty.EndDate = "";
            testCCProperty.ExpirationDays = 5;
            testCCProperty.ChargeConceptName = "Recolectar Basura";
            testCCProperty.MoratoryInterestRate = (float) 2.2;
            testCCProperty.ReciptEmisionDay = 4;

            LegalOwnerDisplayModel testLegalOwner = new LegalOwnerDisplayModel();
            testLegalOwner.Name = "Ferrer S.A.";
            testLegalOwner.DocValue = "301659662";
            testLegalOwner.ResponsibleName = "Daniela Parra Ferrer";
            testLegalOwner.RespDocValue = "282173820";
            testLegalOwner.RespDocType = "Cedula Nacional";
            
            OwnerDisplayModel testOwner = new OwnerDisplayModel();
            testOwner.Name = "Ferrer S.A.";;
            testOwner.DocValue = "301659662";
            testOwner.DocType = "Cedula Juridica";

            //Console.WriteLine(chargeConceptController.ExecuteGetCcChildValue(testCCProperty));

            //Console.WriteLine(userController.ExecuteValidatePassword(user.Name, "123hola"));

            //string password = userController.ExecuteGetPassword(user);

            //Console.WriteLine(password);

            OwnerRegisterModel registerOwner = new OwnerRegisterModel();
            registerOwner.Name = "Ferrer S.A.";
            registerOwner.DocValue = "301659662";
            registerOwner.DocTypeId = 4;
            
            PropertyRegisterModel registerProperty = new PropertyRegisterModel();
            registerProperty.Address = "Condominio Mar del Plata, Filial 186";
            registerProperty.Value = (float)12348471.20;
            registerProperty.PropertyNumber = 1176180;


            //propertyController.ExecuteInsertProperty(registerProperty);
            //ownerController.ExecuteInsertOwner(registerOwner);
            
            ownerController.ExecuteInsertOwnerOfProperty(testProperty, testOwner);
            //List<PropertyDisplayModel> testResult = propertyController.ExecuteGetActiveProperties();
            /*
            foreach (PropertyDisplayModel element in  testResult)
            {
                Console.WriteLine(element.Address);
                //Console.WriteLine(element.isAdmin);
                Console.WriteLine("-----------");
            }
            */
            
            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}