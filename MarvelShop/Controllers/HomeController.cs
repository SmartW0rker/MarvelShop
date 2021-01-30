using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarvelShop.Contexts;
using MarvelShop.Models;

namespace MarvelShop.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext context;
        public HomeController()
        {
            context = new AppDbContext();
        }
        public ActionResult Formi()
        {
            context.SaveChanges();
            return View();
        }

        public ActionResult Pogledi()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Izvestai()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Submit(Proizvod proizvod)
        {
            int id = 0;
            List<Proizvod> proizvodi = context.Proizvodi.ToList();
           foreach (Proizvod p in proizvodi)
            {
                if (p.id_proizvod > id)
                    id = p.id_proizvod;
            }
          
            proizvod.id_proizvod = id + 1;
            context.Proizvodi.Add(proizvod);
            context.SaveChanges();
            return View(proizvod);
        }
    }
}