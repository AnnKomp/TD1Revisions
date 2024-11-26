namespace BlazorTD1Revisions.Models
{
    public class TypeProduit
    {
        public int IdTypeProduit { get; set; }

        public string? NomTypeProduit { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is TypeProduit produit &&
                   IdTypeProduit == produit.IdTypeProduit &&
                   NomTypeProduit == produit.NomTypeProduit;
        }
    }
}
