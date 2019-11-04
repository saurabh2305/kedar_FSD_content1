using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShopWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShopWebMVC.Controllers
{
    [Route("products")]
    public class ProductController : Controller
    {
        private EShopWebMVC.infrastructure.ShopDbContext db;
        private readonly int PageSize = 5;
        //static category data
        //private static List<Category> categories = new List<Category>()
        //{
        //    new Category{Id=1,Name="Mobile",Description="Smart Mobiles"},
        //    new Category{Id=2,Name="Laptops",Description="Latest laptops" }
        //};
        public ProductController(EShopWebMVC.infrastructure.ShopDbContext dbContext)
        {
            this.db = dbContext; // inject dbcontext
        }
        [HttpGet]
        public IActionResult Index( int currentpage=1)
        {
            ViewBag.PageCount =(int)Math.Ceiling(db.Products.Count() /(decimal)PageSize);
            ViewBag.Currentpage = currentpage;
            var products = GetPagedproducts(currentpage);
            //var products = db.Products.Select(c => new Product
            //{
            //    id =c.id,CategoryId =c.CategoryId,
            //    Name = c.Name,Price = c.Price,
            //    Quantity =c.Quantity,Category =c.Category,Brand =c.Brand,
            //    ManufacturingDate =c.ManufacturingDate
            //});
            return View(products);
        }
        [NonAction]
        private IEnumerable<Product> GetPagedproducts (int pageNo)
        {
            return db.Products.Include(p => p.Category)
                .Skip(PageSize * (pageNo - 1)).Take(PageSize);
        }
        [HttpGet("add",Name ="Addproduct")]
        public IActionResult Addproduct()
        {
            ViewBag.Categories = db.Categories.ToList();
            //ViewBag.Categories = categories;
            return View();
        }
        [HttpPost("add",Name ="Addproduct")]
        public async Task<IActionResult> AddproductAsync(Product product)
        {
            if(ModelState.IsValid)
            {
              await  db.Products.AddAsync(product);
              await  db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = db.Categories.ToList();
                return View("Addproduct",product);
            }
        }
        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var product = db.Products.Find(id);
            if(product!= null)
            {
                ViewBag.Categories = db.Categories.ToList();
                return View(product);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
        [HttpPost("edit/{id}")]
        public async Task<IActionResult> EditAsync(Product product)
        {
            if(ModelState.IsValid)
            {
                db.Entry<Product>(product).State = EntityState.Modified;// entity state as modified
                await db.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.Categories = db.Categories.ToList();
                return View("Edit",product);
            }
        }
    }
}