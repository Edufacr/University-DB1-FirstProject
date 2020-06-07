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
            CreateHostBuilder(args).Build().Run();    
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}