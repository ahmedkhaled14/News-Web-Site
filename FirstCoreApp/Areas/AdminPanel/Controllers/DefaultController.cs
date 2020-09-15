using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreApp.Areas.AdminPanel.Controllers
{
    public class AdminNumbers
    {
        public int Team { get; set; }
        public int Neews { get; set; }
        public int Conttact { get; set; }
        public int Cats { get; set; }
    }

    [Area("AdminPanel")]
    public class DefaultController : Controller
    {
     readonly   NewsContext db;
        public DefaultController (NewsContext context)
        {
            db = context;
        }

       
        public IActionResult Index()
        {
            int TeamCount = db.teamMembers.Count();
            int NewsCount = db.news.Count();
            int ContactCount = db.contacts.Count();
            int CategoriesCount = db.Categories.Count();

            return View(new AdminNumbers
            {
                Team = TeamCount,
                Neews = NewsCount,
               Conttact = ContactCount,
               Cats = CategoriesCount
            });
        }
    }




   
}