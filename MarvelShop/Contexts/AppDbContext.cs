using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MarvelShop.Models;
using Npgsql;
using MarvelShop.Models;

namespace MarvelShop.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext() : base(nameOrConnectionString: "MyConection")
        {

        }   
        public DbSet<Covek> Lugje{ get; set; }
        public DbSet<Vraboten> Vraboteni { get; set; }
        public DbSet<Klient> Klienti { get; set; }
        public DbSet<Kosnicka> Kosnicki { get; set; }
        public DbSet<Prodavnica> Prodavnici { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<E_vo> E_Vo { get; set; }
        public DbSet<Se_naogja_vo> Se_Naogja_Vo{ get; set; }

    }
    
}