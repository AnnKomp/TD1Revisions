using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TD1Revisions.Models.EntityFramework
{
    [PrimaryKey("IdTypeProduit")]
    [Table("typeproduit")]
    public partial class TypeProduit
    {

        [Key]
        [Column("idtypeproduit")]
        public int IdTypeProduit { get; set; }

        [Column("nomtypeproduit")]
        public string NomTypeProduit { get; set; }

        [InverseProperty(nameof(Produit.IdTypeProduitNavigation))]
        public virtual ICollection<Produit> Produits { get; set; } = new List<Produit>();

    }
}
