using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TD1Revisions.Models.EntityFramework
{
    [PrimaryKey("IdProduit")]
    [Table("Produit")]
    public partial class Produit
    {
        [Key]
        [Column("idproduit")]
        public int IdProduit { get; set; }

        [Column("nomproduit")]
        public string NomProduit { get; set; }


        [Column("description")]
        public string Description { get; set; }


        [Column("nomphoto")]
        public string NomPhoto { get; set; }


        [Column("uriphoto")]
        public string UriPhoto { get; set; }

        //faire en sorte que le stockreel ne soit pas < stock min et > stock max
        [Column("stockreel")]
        public int StockReel { get; set; }


        [Column("stockmin")]
        public int StockMin { get; set; }


        [Column("stockmax")]
        public int StockMax { get; set; }

        [ForeignKey("idmarque")]
        [InverseProperty(nameof(Marque.Produits))]
        public virtual Marque IdMarqueNavigation { get; set; } = null!;


        [ForeignKey("idtypeproduit")]
        [InverseProperty(nameof(TypeProduit.Produits))]
        public virtual TypeProduit IdTypeProduitNavigation { get; set; } = null!;
    }
}
