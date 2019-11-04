using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreServiceDemo.Models;
using DotNetCoreServiceDemo.services;
using Microsoft.Extensions.Configuration;

namespace DotNetCoreServiceDemo.Controllers
{
    public class HomeController : Controller
    {
        private IDataManager dm;
        //private IConfiguration configuration;
        public HomeController(IDataManager datamanger /*IConfiguration config*/)
        {
            this.dm = datamanger;
           // this.configuration = config;
        }
        public IActionResult Index([FromServices] IConfiguration configuration) // using from services attribute injecting service
        {
            ViewBag.Message = dm.GetData();
            ViewBag.Username = configuration.GetValue<string>("UserDetails:Username");
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
