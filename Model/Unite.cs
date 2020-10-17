using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoutiqueWin.Model
{
    public class Unite
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20), Required]
        public string libelle { get; set; }
    }
}