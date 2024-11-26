using Microsoft.EntityFrameworkCore;

namespace TD1Revisions.Models.EntityFramework
{
    public partial class ProduitsDBContext : DbContext
    {
        public ProduitsDBContext() { }
        
        public ProduitsDBContext(DbContextOptions<ProduitsDBContext> options) 
            : base(options) { }

        public virtual DbSet<Produit> Produits { get; set; } = null!;
        public virtual DbSet<Marque> Marques { get; set; } = null!;
        public virtual DbSet<TypeProduit> TypeProduits { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=ProdDB;uid=postgres;password=postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasKey(e => new { e.IdProduit })
                    .HasName("pk_produit");

                entity.HasOne(d => d.IdMarqueNavigation).WithMany(p => p.Produits)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produit_marque");

                entity.HasOne(d => d.IdTypeProduitNavigation).WithMany(p => p.Produits)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produit_typeproduit");

                //entity.HasData(
                //    new Produit
                //    {
                //        IdProduit = 1,
                //        NomProduit = "chemise ultra xxxxxxs",
                //        Description = "chemise tres petite parada",
                //        NomPhoto = "chemise petite",
                //        UriPhoto = "chemisepetite.png",
                //        IdMarque = 1,
                //        IdTypeUtilisateur = 1,
                //        IdTypeProduitNavigation = new TypeProduit { IdTypeProduit = 1, NomTypeProduit = "chemise" },
                //        IdMarqueNavigation = new Marque { IdMarque = 1, NomMarque = "Prada" },
                //        StockReel = 17,
                //        StockMin = 5,
                //        StockMax = 30
                //    });
            });


            modelBuilder.Entity<Marque>(entity =>
            {
                entity.HasKey(e => new { e.IdMarque })
                .HasName("pk_marque");

                //entity.HasData(
                //    new Marque
                //    {
                //        IdMarque = 2,
                //        NomMarque = "aliexpress"
                //    },
                //    new Marque
                //    {
                //        IdMarque = 3,
                //        NomMarque = "dior"
                //    },
                //    new Marque
                //    {
                //        IdMarque = 4,
                //        NomMarque = "LV"
                //    });

            });



            modelBuilder.Entity<TypeProduit>(entity =>
            {
                entity.HasKey(e => new { e.IdTypeProduit })
                .HasName("pk_typeproduit");

                //entity.HasData(
                //    new TypeProduit
                //    {
                //        IdTypeProduit = 2,
                //        NomTypeProduit = "parfum"
                //    },
                //    new TypeProduit
                //    {
                //        IdTypeProduit = 3,
                //        NomTypeProduit = "lunettes"
                //    },
                //    new TypeProduit
                //    {
                //        IdTypeProduit = 4,
                //        NomTypeProduit = "pantalons"
                //    });

            });


            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
