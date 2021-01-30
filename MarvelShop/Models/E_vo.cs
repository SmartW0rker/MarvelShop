using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarvelShop.Models
{
    [Table("e_vo", Schema = "public")]

    public class E_vo
    {
        
        //[ForeignKey("id_proizvod")]
      //  public Proizvod Proizvod { get; set; }
        [Key]
        [Column(Order = 0)]
        public int id_proizvod { get; set; }
        [Key]
        [Column(Order = 1)]
        public int id_kosnicka { get; set; }
       // [ForeignKey("id_kosnicka")]
       // public Kosnicka Kosnicka { get; set; }
    }
}