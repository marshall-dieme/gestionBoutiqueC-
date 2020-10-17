using System;
using System.ComponentModel.DataAnnotations;

namespace BoutiqueWin.Model
{
    public class Categorie
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10), Required]
        public string CodeCategorie { get; set; }

        [StringLength(100), Required]
        public string Denomination { get; set; }
    }
}