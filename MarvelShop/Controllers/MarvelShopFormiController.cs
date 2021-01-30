using MarvelShop.Contexts;
using MarvelShop.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace MarvelShop.Controllers
{
    public class MarvelShopFormiController : Controller
    {
        AppDbContext context;
        public MarvelShopFormiController()
        {
            context = new AppDbContext();
        }
        // GET: MarvelShopFormi
        public ActionResult Formi()
        {

            return View();
        }
        public ActionResult Forma1()
        {

            return View(context.Proizvodi.ToList());
        }
        public ActionResult Add(int id)
        {

            
            ViewBag.IdProizvod = id;
         
            return View(context.Kosnicki.ToList());
        }
        [Route("/Abc/Details/{id?}/{date?}")]
        public ActionResult Dodadi(int id, int date)
        {
            E_vo o = new E_vo();
            o.id_kosnicka = id;
            o.id_proizvod = date;
            if (context.E_Vo.Find(date, id) != null)
                return View("Forma1", context.Proizvodi.ToList());
            else
            {
                context.Proizvodi.Find(id).kolicina--;
                context.Kosnicki.Find(id).broj_proizvodi = context.Kosnicki.Find(id).broj_proizvodi + 1;



                context.E_Vo.Add(o);

                context.SaveChanges();
                return View(context.Kosnicki.ToList());
            }
        }
        public ActionResult Kupi(int id)
        {
            context.Kosnicki.Find(id).status = false;
            context.SaveChanges();
            return View(context.Kosnicki.ToList());
        }
        public ActionResult Forma2()
        {
            return View();
        }
        public ActionResult Naracka()
        {
            return View("Dodadi", context.Kosnicki.ToList());
        }
        public ActionResult NovProizvod()
        {
            return View();
        }
    }
}