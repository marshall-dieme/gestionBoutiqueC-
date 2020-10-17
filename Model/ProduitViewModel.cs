using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BoutiqueWin.Model
{
    public class ProduitViewModel
    {

        public int Id { get; set; }

        public string CodeProduit { get; set; }

        public string DesignationProduit { get; set; }

        public int Quantite { get; set; }

        public int? QuantiteMinimale { get; set; }

        public int? QuantiteQritique { get; set; }

        public int Pu { get; set; }

        public string Categorie { get; set; }


    }
}