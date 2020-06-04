using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using University_DB1_FirstProject.Controllers;
using University_DB1_FirstProject.Models;

namespace University_DB1_FirstProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            OwnerRegisterModel owner = new OwnerRegisterModel();
            owner.Name = "Jorge Gutierrez";
            owner.DocValue = 118090772;
            owner.DocTypeId = 1;
            OwnerController controller = new OwnerController();
            
            controller.executeInsertOwner(owner);
            
            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}