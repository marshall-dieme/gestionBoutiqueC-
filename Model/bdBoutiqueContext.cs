using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BoutiqueWin.Model
{
    public class bdBoutiqueContext:DbContext
    {
        public bdBoutiqueContext() : base("connBoutique") { }

        public DbSet<Categorie> categories { get; set; }

        public DbSet<Produit> produits { get; set; }

        public DbSet<Stock> stocks { get; set; }

        public DbSet<ErrorLog> errorLogs { get; set; }

        public DbSet<Unite> unites { get; set; }
    }
}