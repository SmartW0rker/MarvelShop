using MarvelShop.Contexts;
using MarvelShop.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarvelShop.Controllers
{
    public class MarvelShopPoglediController : Controller
    {
        AppDbContext context;
        public MarvelShopPoglediController()
        {
            context = new AppDbContext();
        }
        // GET: MarvelShopPogledi
        public ActionResult CenaKosnicka()
        {
            var conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=181134;Database=postgres");
            conn.Open();
            string query = "select * from cena_kosnicka;";

            var cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            List<CenaKosnicka> cenaKosnicki = new List<CenaKosnicka>();
            
            while (reader.Read())
            {
                CenaKosnicka cenaKosnicka = new CenaKosnicka();
                cenaKosnicka.id_kosnicka = reader.GetInt32(0);
                cenaKosnicka.sum = reader.GetInt32(1);
                cenaKosnicka.broj_proizvodi = reader.GetInt32(2);
                cenaKosnicki.Add(cenaKosnicka);
                // Console.WriteLine(String.Format("{0}, {1}, {2}", reader["fName"], reader["lName"], reader["preference"]));
            }
            
            return View(cenaKosnicki);
        }
        public ActionResult Kupeno()
        {
            var conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=181134;Database=postgres");
            conn.Open();
            string query = "select * from Proizvodi_kupeni_od_klient;";

            var cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            List<KupenoKlient> kupenoKlienti = new List<KupenoKlient>();

            while (reader.Read())
            {
                KupenoKlient kupenoKlient = new KupenoKlient();
                kupenoKlient.ime = reader.GetString(0);
                kupenoKlient.prezime = reader.GetString(1);
                kupenoKlient.ime_proizvod = reader.GetString(2);
                kupenoKlient.id_proizvod = reader.GetInt32(3);
                kupenoKlienti.Add(kupenoKlient);
      
            }
            return View(kupenoKlienti);
        }
        public ActionResult PotroseniPariKlienti()
        {
            var conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=181134;Database=postgres");
            conn.Open();
            string query = "select * from Promet_od_klient;";

            var cmd = new NpgsqlCommand(query, conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            List<KlientPromet> klientPrometi = new List<KlientPromet>();

            while (reader.Read())
            {
                KlientPromet klientPromet = new KlientPromet();
                klientPromet.ime = reader.GetString(0);
                klientPromet.prezime = reader.GetString(1);
                klientPromet.sum = reader.GetInt32(2);
                klientPrometi.Add(klientPromet);
                
            }
            return View(klientPrometi);
        }
    }
}