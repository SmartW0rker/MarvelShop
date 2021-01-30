using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarvelShop.Models
{
    [Table("telefonski_broj", Schema = "public")]

    public class Telefonski_broj
    {
        [Key]
        public string embg {get; set; }
        public string broj { get; set; }

    }
}