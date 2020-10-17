using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoutiqueWin.Model
{
    public class StockViewModel
    {

        public int Id { get; set; }

        public string Numero { get; set; }

        public DateTime Date { get; set; }

        public int Quantite { get; set; }

        public int PrixUnitaire { get; set; }

        public int Total { get; set; }

        public string Type { get; set; }

        public string Produit { get; set; }
    }
}