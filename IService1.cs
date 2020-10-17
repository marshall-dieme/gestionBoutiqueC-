using BoutiqueWin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BoutiqueWin
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: ajoutez vos opérations de service ici

        [OperationContract]
        List<Categorie> GetCategories();

        [OperationContract]
        List<Categorie> GetFilteredCategories(string search);

        [OperationContract]
        Categorie GetCategorieById(int id);

        [OperationContract]
        Produit GetProduitById(int id);

        [OperationContract]
        List<ProduitViewModel> GetProduits();

        [OperationContract]
        List<StockViewModel> GetEntrees();

        [OperationContract]
        List<StockViewModel> GetSorties();

        [OperationContract]
        bool AddCategorie(Categorie categorie);

        [OperationContract]
        bool AddProduit(Produit produit);

        [OperationContract]
        bool AddStock(Stock stock);

        [OperationContract]
        bool UpdateCategorie(Categorie categorie);

        [OperationContract]
        bool UpdateProduit(Produit produit);

        [OperationContract]
        bool UpdateStock(Stock stock);

        [OperationContract]
        bool DeleteCategorie(int id);

        [OperationContract]
        bool DeleteProduit(int id);

        [OperationContract]
        bool DeleteStock(int id);

        [OperationContract]
        bool WriteCsv(List<Categorie> list);

        [OperationContract]
        List<Unite> GetUnites();

        [OperationContract]
        string StockGenerator();

        [OperationContract]
        bool ExportXls();

    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
