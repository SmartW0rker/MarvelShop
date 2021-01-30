using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarvelShop.Models
{
    [Table("kosnicka", Schema = "public")]

    public class Kosnicka
    {
        [Key]
        public int id_kosnicka { get; set; }
        public int broj_proizvodi { get; set; }
        public bool status { get; set; }
        public string embg { get; set; }


    }
}