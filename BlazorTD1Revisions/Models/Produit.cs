using System.ComponentModel.DataAnnotations;

namespace BlazorTD1Revisions.Models
{
    public class Produit
    {
        public int IdProduit { get; set; }

        [Required(ErrorMessage = "Le champ Nom du produit est obligatoire.")]
        public string NomProduit { get; set; }

        public string Description { get; set; }

        public int StockReel { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }

        [Required(ErrorMessage = "Le champ Marque est obligatoire.")]
        [Range(1, int.MaxValue, ErrorMessage = "Le champ Marque est obligatoire.")]
        public int IdMarque { get; set; }
        public Marque? Marque { get; set; }

        [Required(ErrorMessage = "Le champ TypeProduit est obligatoire.")]
        [Range(1, int.MaxValue, ErrorMessage = "Le champ Type de produit est obligatoire.")]
        public int IdTypeProduit { get; set; }
        public TypeProduit? TypeProduit { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Produit produit &&
                IdProduit == produit.IdProduit &&
                NomProduit == produit.NomProduit &&
                Description == produit.Description &&
                StockMax == produit.StockMax &&
                StockMin == produit.StockMin &&
                StockReel == produit.StockReel &&
                IdMarque == produit.IdMarque &&
                IdTypeProduit == produit.IdTypeProduit;
        }
    }
}
