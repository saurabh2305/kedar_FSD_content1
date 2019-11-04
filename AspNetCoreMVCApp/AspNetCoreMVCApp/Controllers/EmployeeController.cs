using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AspNetCoreMVCApp.DI;

namespace AspNetCoreMVCApp.Controllers
{
    [Route("employees")] 
    public class EmployeeController : Controller
    {
        DataService ds;
        public EmployeeController(DataService ds)
        {
            this.ds = ds;
        }
        [HttpGet("List", Name ="EmpList")]
        public IActionResult Index()
        {
            ViewBag.DIData = ds.Message; // state management using dependency injection
            string message = "Hello How r u";
            var data = Encoding.UTF8.GetBytes(message);
            HttpContext.Session.Set("message", data);
            return View();
        }
        public IActionResult Details()
        {        
            ViewBag.Message = HttpContext.Session.GetString("message");
            return View();
        }
    }
}