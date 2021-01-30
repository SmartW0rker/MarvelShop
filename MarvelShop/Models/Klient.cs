using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarvelShop.Models
{
    [Table("klient", Schema = "public")]

    public class Klient
    {
        [Key]
        public string embg { get; set; }
        public bool klub_karticka { get; set; }

    }
}