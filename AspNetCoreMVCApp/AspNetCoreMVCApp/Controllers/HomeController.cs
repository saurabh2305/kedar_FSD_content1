using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreMVCApp.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using AspNetCoreMVCApp.DI;

namespace AspNetCoreMVCApp.Controllers
{
    public class HomeController : Controller
    {
        IMemoryCache cache;
        IDistributedCache distCache;
        DataService ds;
        public HomeController(IMemoryCache cache,IDistributedCache distCache, DataService ds)
        {
            this.cache = cache;
            this.distCache = distCache;
            this.ds = ds;
        }
        public IActionResult Index()
        {
            ds.Message = "This is DI demo";
            var data = cache.Get<DateTime?>("now");
            // InMemory caching method
            if (data==null)
            {
                data = DateTime.Now;
                cache.Set<DateTime?>("now", data, DateTimeOffset.Now.AddMinutes(3));
            }
            ViewBag.LoadingTime = data;
           
            // Distributed caching
          var cacheData = distCache.GetString("users");
         if(string.IsNullOrEmpty(cacheData))
            {
                Dictionary<int, string> mydata = new Dictionary<int, string>
            {
                {101,"KK" },
                {102,"cc" },
                {103,"BB" }
            };
                distCache.SetString("users", JsonConvert.SerializeObject(mydata));
                ViewBag.Users = mydata;
                ViewBag.Source = "Loaded initially";
            }
            else
            {
                ViewBag.Users = JsonConvert.DeserializeObject<Dictionary<int, string>>(cacheData);
                ViewBag.Source = "Loaded from cache";
            }
            

            return View();
        }

        public IActionResult Privacy()
        {
            if((bool)HttpContext.Items["IsVerified"]) // object coverted to bool
            {
                ViewBag.Message = "Request valid";
            }
            else
            {
                ViewBag.Message = "Request data is invalid";
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
