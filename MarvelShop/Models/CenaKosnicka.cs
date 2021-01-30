using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace MarvelShop.Models
{
    public class CenaKosnicka
    {
        [Key]
        public int id_kosnicka { get; set; }
        public int sum { get; set; }
        public int broj_proizvodi { get; set; }

    }
}