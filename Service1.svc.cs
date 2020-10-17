using BoutiqueWin.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using OfficeOpenXml;

namespace BoutiqueWin
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        private bdBoutiqueContext db = new bdBoutiqueContext();
        public bool AddCategorie(Categorie categorie)
        {
            bool rep = false;
            try
            {
                db.categories.Add(categorie);
                db.SaveChanges();
                rep = true;
            }
            catch (Exception e)
            {
                ErrorLog error = new ErrorLog();
                error.Libelle = "Erreur lors de l'Ajout dans la base de donnée";
                error.Description = e.ToString();
                GetError(error);
            }
            return rep;
        }

        public bool AddStock(Stock stock)
        {
            bool rep = false;
            try
            {
                db.stocks.Add(stock);
                db.SaveChanges();
                rep = true;
            }
            catch (Exception e)
            {
                ErrorLog error = new ErrorLog();
                error.Libelle = "Erreur lors de l'Ajout dans la base de donnée";
                error.Description = e.ToString();
                GetError(error);
            }
            return rep;
        }

        public bool AddProduit(Produit produit)
        {
            bool rep = false;
            try
            {
                db.produits.Add(produit);
                db.SaveChanges();
                rep = true;
            }
            catch (Exception e)
            {
                ErrorLog error = new ErrorLog();
                error.Libelle = "Erreur lors de l'Ajout dans la base de donnée";
                error.Description = e.ToString();
                GetError(error);
            }
            return rep;
        }

        //DELETE SECTION
        public bool DeleteCategorie(int id)
        {
            bool retour = false;
            try
            {
                Categorie st = db.categories.Find(id);
                db.categories.Remove(st);
                retour = true;
            }
            catch (Exception e) {
                ErrorLog error = new ErrorLog();
                error.Libelle = "Erreur lors de la suppression dans la base de donnée";
                error.Description = e.ToString();
                GetError(error);
            }

            return retour;
        }

        public bool DeleteProduit(int id)
        {
            bool retour = false;
            try
            {
                Produit st = db.produits.Find(id);
                db.produits.Remove(st);
                db.SaveChanges();
                retour = true;
            }
            catch (Exception e) {
                ErrorLog error = new ErrorLog();
                error.Libelle = "Erreur lors de la suppression dans la base de donnée";
                error.Description = e.ToString();
                GetError(error);
            }

            return retour;
        }

        public bool DeleteStock(int id)
        {
            bool retour = false;
            try
            {
                Stock st = db.stocks.Find(id);
                db.stocks.Remove(st);
                retour = true;
            }
            catch (Exception e) {
                ErrorLog error = new ErrorLog();
                error.Libelle = "Erreur lors de la suppression dans la base de donnée";
                error.Description = e.ToString();
                GetError(error);
            }

            return retour;
        }
        //END DELETE SECTION

        //GET SECTION
        public List<Categorie> GetCategories()
        {
            return db.categories.ToList();
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<StockViewModel> GetEntrees()
        {
            List<StockViewModel> liste = new List<StockViewModel>();
            var entrees = db.stocks.Where(e => e.Type == "Entree").ToList();
            foreach (var e in entrees)
            {
                StockViewModel st = new StockViewModel()
                {
                    Numero = e.Numero,
                    Id = e.Id,
                    Date = DateTime.Parse(e.Date),
                    Quantite = e.Quantite,
                    Type = e.Type,
                    Produit = db.produits.Find(e.IdProduit).DesignationProduit
                };
            }

            return liste;
        }

        public List<ProduitViewModel> GetProduits()
        {
            List<ProduitViewModel> liste = new List<ProduitViewModel>();
            var produits = db.produits.ToList();
            foreach(var p in produits)
            {
                ProduitViewModel pvm = new ProduitViewModel()
                {
                    Id = p.Id,
                    CodeProduit = p.CodeProduit,
                    DesignationProduit = p.DesignationProduit,
                    Quantite = (int)p.Quantite,
                    QuantiteMinimale = (int?)p.QuantiteMinimale,
                    QuantiteQritique = (int?)p.QuantiteQritique,
                    Pu = (int)p.PrixUnitaire,
                    Categorie = db.categories.Find(p.IdCategorie).Denomination
                };
                liste.Add(pvm);
            }
            return liste;
        }

        public List<StockViewModel> GetSorties()
        {
            List<StockViewModel> liste = new List<StockViewModel>();
            var entrees = db.stocks.Where(e => e.Type == "Sortie").ToList();
            foreach (var e in entrees)
            {
                StockViewModel st = new StockViewModel()
                {
                    Numero = e.Numero,
                    Id = e.Id,
                    Date = DateTime.Parse(e.Date),
                    Quantite = e.Quantite,

                };
            }

            return liste;
        }
        //END GET SECTION

        //UPDATE SECTION
        public bool UpdateCategorie(Categorie categorie)
        {
            bool retour = false;
            try
            {
                db.Entry(categorie).State = EntityState.Modified;
                db.SaveChanges();
                retour = true;
            }
            catch (Exception e)
            {
                ErrorLog error = new ErrorLog();
                error.Libelle = "Erreur lors de la mise à jour dans la base de donnée";
                error.Description = e.ToString();
                GetError(error);
            }
            return retour;
        }

        public bool UpdateStock(Stock stock)
        {
            bool retour = false;
            try
            {
                db.Entry(stock).State = EntityState.Modified;
                db.SaveChanges();
                retour = true;
            }
            catch (Exception e)
            {
                ErrorLog error = new ErrorLog();
                error.Libelle = "Erreur lors de la mise à jour dans la base de donnée";
                error.Description = e.ToString();
                GetError(error);
            }
            return retour;
        }

        public bool UpdateProduit(Produit produit)
        {
            bool retour = false;
            try
            {
                db.Entry(produit).State = EntityState.Modified;
                db.SaveChanges();
                retour = true;
            }
            catch (Exception e)
            {
                ErrorLog error = new ErrorLog();
                error.Libelle = "Erreur lors de la mise à jour dans la base de donnée";
                error.Description = e.ToString();
                WriteError(error);
            }
            return retour;
        }
        //END UPDATE SECTION

        /// <summary>
        /// Filter Categories
        /// </summary>
        /// <param name="search">the word to search</param>
        /// <returns></returns>
        public List<Categorie> GetFilteredCategories(string search)
        {
            return db.categories.Where(c => c.CodeCategorie.Contains(search) || c.Denomination.Contains(search)).ToList();
        }

        public Categorie GetCategorieById(int id)
        {
            return db.categories.Find(id);
        }


        /// <summary>
        /// Write Error in a TXT file
        /// </summary>
        /// <param name="error">the Error Generated</param>
        public static void WriteError(ErrorLog error)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~/Errors/erreur.txt");
            try
            {
                //if(verifFile(path))
                //{
                    System.IO.TextWriter writeFile = new StreamWriter(path, true);
                    writeFile.WriteLine(error.Libelle + "\t\t\t" + error.dateErreur);
                    writeFile.WriteLine("---------------------------------------------------------------------------------------");
                    writeFile.WriteLine(error.Description);

                    writeFile.Flush();
                    writeFile.Close();
                    writeFile = null;
               /* }
                else
                {
                    Console.WriteLine("Erreur!!!");
                }*/
                
            }
            catch (IOException e)
            {
                WriteLog(error);
            }
        }


        /// <summary>
        /// Write Error in the Database
        /// </summary>
        /// <param name="error">The Error created</param>
        /// <returns></returns>
        public static bool GetError(ErrorLog error)
        {
            bool res = false;
            bdBoutiqueContext db1 = new bdBoutiqueContext();
            try
            {
                db1.errorLogs.Add(error);
                db1.SaveChanges();
                res = true;
            }
            catch(Exception ex)
            {
                WriteError(error);
            }
            return res;
        }

        /// <summary>
        /// Write Error in the System Log
        /// </summary>
        /// <param name="error"></param>
        public static void WriteLog(ErrorLog error)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "WinBoutique";
                eventLog.WriteEntry(string.Format("date: {0}, libelle: {1}, description {2}", error.dateErreur, error.Libelle, error.Description), EventLogEntryType.Information, 101, 1);
            }
        }

        /// <summary>
        /// Check and Create a File if not Exist
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private static bool verifFile(string file)
        {
            bool rep = false;
            if (!File.Exists(file))
            {
                // Creation du fichier
                File.Create(file);
                System.Threading.Thread.Sleep(5000);
                rep = true;
            }
            return rep;
        }

        /// <summary>
        /// Create CSV File
        /// </summary>
        /// <param name="list">List of all Categories</param>
        /// <returns></returns>
        public bool WriteCsv(List<Categorie> list)
        {
            
            string path = System.Web.HttpContext.Current.Server.MapPath("~/Rapports/categorie.csv");
            try
            {
                verifFile(path);
                System.IO.TextWriter writeFile = new StreamWriter(path, true);
                writeFile.WriteLine("N°;Code;Libelle");
                string delimiter = ";";

                StringBuilder sb = new StringBuilder();
                foreach (var c in list)
                {

                    sb.AppendLine(string.Join(delimiter, string.Format("{0};{1};{2}", c.Id, c.CodeCategorie, c.Denomination)));
                   
                }
                File.WriteAllText(path, sb.ToString());
                return true;
                
            }
            catch (Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// Get one product
        /// </summary>
        /// <param name="id">The id of the product</param>
        /// <returns></returns>
        public Produit GetProduitById(int id)
        {
            return db.produits.Find(id);
        }

        /// <summary>
        /// Get All the measurement units
        /// </summary>
        /// <returns></returns>
        public List<Unite> GetUnites()
        {
            return db.unites.ToList();
        }

        /// <summary>
        /// Generate supply or sale number
        /// </summary>
        /// <returns></returns>
        public string StockGenerator()
        {
            int id = int.Parse(db.stocks.SingleOrDefault(st => st.Id == db.stocks.Max(s => s.Id))?.Id.ToString() ?? "0");
            
            return string.Format("ST-{0}{1}{2}-{3}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, id+1);
        }

        /// <summary>
        /// Generate Excel File from products list
        /// </summary>
        /// <returns></returns>
        public bool ExportXls()
        {
            bool rep = false;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Worksheet1");

                var headerRow = new List<string[]>()
                {
                    new string[] { "ID", "Code", "Description", "Quantité en Stock", "Quantité Minimale", "Quantié Critique", "Prix Unitaire", "Categorie" }
                };

                // Determine the header range
                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

                // Target a worksheet
                var worksheet = excel.Workbook.Worksheets["Worksheet1"];

                // Popular header row data
                worksheet.Cells[headerRange].LoadFromArrays(headerRow);

                //Styling the Header
                worksheet.Cells[headerRange].Style.Font.Bold = true;
                worksheet.Cells[headerRange].Style.Font.Size = 14;

                List<ProduitViewModel> liste = GetProduits();

                worksheet.Cells[2, 1].LoadFromCollection(liste);
                worksheet.Cells[2, 1].Style.Font.Size = 12;
                worksheet.Cells[2, 1].Style.Font.Italic = true;

                FileInfo excelFile = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/Rapports/produits.xlsx"));

                excel.SaveAs(excelFile);
            }
            return rep;
        }
    }
}
