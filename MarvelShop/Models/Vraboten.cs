using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarvelShop.Models
{
    [Table("vraboten", Schema = "public")]

    public class Vraboten
    {
        [Key]
        [Column(Order = 1)]
        public string embg { get; set; }

        public string pozicija { get; set; }
        public DateTime datum_vrabotuvajne { get; set; }
        [Key]
        [Column(Order = 2)]
        public int id_prodavnica { get; set; }

    }
}