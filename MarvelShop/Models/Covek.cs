using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarvelShop.Models
{
    [Table("covek", Schema = "public")]

    public class Covek
    {
        [Key]
        public string embg { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string adresa { get; set; }

    }
}