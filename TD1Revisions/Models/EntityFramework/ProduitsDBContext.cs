using Microsoft.EntityFrameworkCore;

namespace TD1Revisions.Models.EntityFramework
{
    public partial class ProduitsDBContext : DbContext
    {
        public ProduitsDBContext() { }
        
        public ProduitsDBContext(DbContextOptions<ProduitsDBContext> options) : base(options) { }

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
            entity.HasKey(e => new { e.IdProduit }).HasName("pk_produit");

            entity.HasOne(d => d.IdMarqueNavigation).WithMany(p => p.Produits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_produit_marque");

            entity.HasOne(d => d.IdTypeProduitNavigation).WithMany(p => p.Produits)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_produit_typeproduit");
            });

            modelBuilder.Entity<Marque>(entity =>
            {
                entity.HasKey(e => new { e.IdMarque }).HasName("pk_marque");

            });

            modelBuilder.Entity<TypeProduit>(entity =>
            {
                entity.HasKey(e => new { e.IdTypeProduit }).HasName("pk_typeproduit");

            });

            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
