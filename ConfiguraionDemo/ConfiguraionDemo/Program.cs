using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ConfiguraionDemo
{
    public class Program
    {
        //private static Dictionary<string, string> configData = new Dictionary<string, string>();
        public static void Main(string[] args)
        {
            //configData.Add("Projector", "Epson");
            //configData.Add("Mobile", "Samsung");
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            // add more configuration file which are created manually like mysettings.xml
            // DO NOT ADD ADDITINAL CONFIGURATION HERE
            //.ConfigureAppConfiguration(config=>
            //{
            //    config.SetBasePath(Directory.GetCurrentDirectory())
            //    .AddXmlFile("mysettings.xml", optional: true)
            //    .AddJsonFile("mysettings.json", optional: true)
            //    .AddInMemoryCollection(configData);
            // })
                .UseStartup<Startup>();
    }
}
