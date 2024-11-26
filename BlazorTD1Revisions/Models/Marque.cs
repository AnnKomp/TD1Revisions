namespace BlazorTD1Revisions.Models
{
    public class Marque
    {
        public int IdMarque { get; set; }

        public string? NomMarque { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Marque marque &&
                   IdMarque == marque.IdMarque &&
                   NomMarque == marque.NomMarque;
        }
    }
}
