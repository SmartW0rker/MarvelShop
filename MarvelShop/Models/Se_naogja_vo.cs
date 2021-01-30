using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarvelShop.Models
{
    [Table("se_naogja_vo", Schema = "public")]

    public class Se_naogja_vo
    {
        [Key]
        [Column(Order = 1)]
        public int id_proizvod { get; set; }
        [Key]
        [Column(Order = 2)]
        public int id_prodavnica { get; set; }

    }
}