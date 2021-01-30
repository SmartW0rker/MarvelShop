using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarvelShop.Models
{
    [Table("proizvod", Schema = "public")]

    public class Proizvod
    {
        [Key]
        public int id_proizvod { get; set; }
        public string legenda { get; set; }
        public int cena_proizvod { get; set; }
        public int kolicina { get; set; }
        public string ime_proizvod { get; set; }


    }
}