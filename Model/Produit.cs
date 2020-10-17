using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoutiqueWin.Model
{
    public class Produit
    {
        [Key]
        public int Id { get; set; }

        [StringLength(4), Required]
        public string CodeProduit { get; set; }

        [StringLength(100), Required]
        public string DesignationProduit { get; set; }

        public int Quantite { get; set; }

        public int QuantiteMinimale { get; set; }

        public int QuantiteQritique { get; set; }

        public int PrixUnitaire { get; set; }

        [StringLength(1000)]
        public string Image { get; set; }

        public int IdCategorie { get; set; }

        public int IdUnite { get; set; }

        /*[ForeignKey("IdCategorie")]
        public virtual Categorie Categorie { get; set; }*/
    }
}