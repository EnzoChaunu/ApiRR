using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RessourcesRelationelles.Class;
using RRelationnelle.Controllers;
using RRelationnelle.Modèles;
using RRelationnelle.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RRelationnelle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    webBuilder.UseStartup<Startup>();
   
                    //webBuilder.Services.AddSingleton<ICategoryService, CategoryService>();
                    //webBuilder.ConfigureServices.AddScoped<ICategoryService, CategoryService>();
                });
       
        
    }


}
