using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConfiguraionDemo.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ConfiguraionDemo.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration configuration;
        private AppConfiguration appConfig;
        public HomeController(IConfiguration config, IOptions<AppConfiguration> options)
        {
            this.appConfig = options.Value;
        }
        //public HomeController(IConfiguration config)
        //{
        //    configuration = config;
        //}
        public IActionResult Index()
        {
            var company = configuration.GetValue<string>("CompanyName");
            // Another way of reading configuration using poco classes
            var companyName1 = appConfig.CompanyName;
            var location = configuration.GetValue<string>("Location");//reading value from appsettings file
            var count = configuration.GetValue<int>("ParticipantCount");//reading value from appsettings file
            var arch = configuration.GetValue<string>("PROCESSOR_ARCHITECTURE"); // reading value of environment variables
            var noOfProcessor = configuration.GetValue<int>("NUMBER_OF_PROCESSORS");//reading value of environment variables
            var title = configuration.GetValue<string>("ProjectDetails:Title");
            var project = configuration.GetSection("ProjectDetails");
            var duration = project["Duration"];
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
