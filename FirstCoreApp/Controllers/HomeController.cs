using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FirstCoreApp.Models;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting;

namespace FirstCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewsContext db;
        public HomeController(NewsContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var result = db.Categories.ToList();
            return View(result);
        }

        public IActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SaveContact(ContactUs model)
        {
            if (ModelState.IsValid)
            {
               db.contacts.Add(model);
               db.SaveChanges();
               return RedirectToAction("index");
            }

            return View("Contact", model);
        }

        public IActionResult Messages()
        {

            return View(db.contacts.ToList());
        } 
        
        public IActionResult TeamMember()
        {

            return View(db.teamMembers.ToList());
        }

        [Authorize]
        public IActionResult News(int id)
        {
            Category c = db.Categories.Find(id);
            ViewBag.cate = c.Name;
            
            
            var result = db.news.Where(x => x.CategoryId == id)
                .OrderByDescending(y=>y.Date).ToList();
           

            return View(result);
        }

        public IActionResult DeleteMessage(int id)
        {
            var News = db.news.Find(id);
            db.news.Remove(News);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        

    }
}
