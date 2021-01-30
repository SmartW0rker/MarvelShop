using MarvelShop.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarvelShop.Controllers
{
    public class MarvelShopIzvestaiController : Controller
    {
        // GET: MarvelShopIzvestai
        public ActionResult ProizvodProfit()
        {
            var conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=181134;Database=postgres");
            conn.Open();
            string query = "select * from( \n"+
" select Proizvod.ime_proizvod,cena_proizvod,sum(cena_proizvod) as suma from Proizvod \n"+
"join E_vo Ev on Proizvod.id_proizvod = Ev.id_proizvod \n"+
"join Kosnicka K on K.id_kosnicka = Ev.id_kosnicka \n"+
"where status = false \n"+
"group by Ev.id_proizvod,Proizvod.ime_proizvod,cena_proizvod \n"+
"order by cena_proizvod \n"+
 ") as profit_proizvodi \n"+

"where suma = (select max(suma) from( \n"+
  "select Proizvod.ime_proizvod, cena_proizvod, sum(cena_proizvod) as suma from Proizvod \n"+
  "join E_vo Ev on Proizvod.id_proizvod = Ev.id_proizvod \n"+
  "join Kosnicka K on K.id_kosnicka = Ev.id_kosnicka \n"+
  "where status = false \n"+
 "group by Ev.id_proizvod, Proizvod.ime_proizvod, cena_proizvod \n"+
  "order by cena_proizvod \n"+
   ") as profit_proizvodi); ";

            var cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            ProizvodWithMaxProfit proizvodMax = new ProizvodWithMaxProfit();

            reader.Read();
            proizvodMax.ime_proizvod = reader.GetString(0);
            proizvodMax.cena_proizvod = reader.GetInt32(1);
            proizvodMax.suma = reader.GetInt32(2);
            ViewBag.ProizvodMax = proizvodMax;
            
            return View();
        }
        public ActionResult ProdadeniParcinja()
        {
            var conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=181134;Database=postgres");
            conn.Open();
            string query = "select ime_proizvod,kolicina,count(ime_proizvod) as count from Klient \n"+
"join Kosnicka K on Klient.EMBG = K.EMBG \n"+
"join e_vo ev on K.id_kosnicka = ev.id_kosnicka \n"+
"join proizvod p on ev.id_proizvod = p.id_proizvod \n" +
"where status = false \n" +
"group by ime_proizvod,kolicina \n"+
"order by count desc; ";

            var cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            List<ProdadeniProizvodi> prodadeniProizvodi = new List<ProdadeniProizvodi>();

            while (reader.Read())
            {
                ProdadeniProizvodi prodadenProizvod = new ProdadeniProizvodi();
                prodadenProizvod.ime_proizvod= reader.GetString(0);
                prodadenProizvod.kolicina = reader.GetInt32(1);
                prodadenProizvod.count = reader.GetInt32(2);
                prodadeniProizvodi.Add(prodadenProizvod);
               
            }
            return View(prodadeniProizvodi);
        }
    }
}