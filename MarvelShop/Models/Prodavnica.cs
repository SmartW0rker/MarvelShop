using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarvelShop.Models
{
    [Table("prodavnica", Schema = "public")]

    public class Prodavnica
    {
        [Key]
        public int id_prodavnica { get; set; }
        public int broj_vraboteni { get; set; }
        public string ime_prodavnica { get; set; }
        public string grad_otvorena { get; set; }

    }
}