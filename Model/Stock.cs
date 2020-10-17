using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoutiqueWin.Model
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20), Required]
        public string Numero { get; set; }

        //[DataType(DataType.Date)]
        [StringLength(20)]
        public string Date { get; set; }

        public int Quantite { get; set; }

        public int PrixUnitaire { get; set; }

        public int Total { get; set; }

        [StringLength(10)]
        public string Type { get; set; }

        public int IdProduit { get; set; }

        /*[ForeignKey("IdProduit")]
        public virtual Produit Produit { get; set; }*/

        public Stock()
        {
            Date = DateTime.Now.ToString();
        }

    }
}