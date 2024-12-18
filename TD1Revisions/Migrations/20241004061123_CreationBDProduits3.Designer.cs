﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TD1Revisions.Models.EntityFramework;

#nullable disable

namespace TD1Revisions.Migrations
{
    [DbContext(typeof(ProduitsDBContext))]
    [Migration("20241004061123_CreationBDProduits3")]
    partial class CreationBDProduits3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TD1Revisions.Models.EntityFramework.Marque", b =>
                {
                    b.Property<int>("IdMarque")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("idmarque");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdMarque"));

                    b.Property<string>("NomMarque")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nommarque");

                    b.HasKey("IdMarque")
                        .HasName("pk_marque");

                    b.ToTable("Marque");
                });

            modelBuilder.Entity("TD1Revisions.Models.EntityFramework.Produit", b =>
                {
                    b.Property<int>("IdProduit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("idproduit");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdProduit"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("NomPhoto")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nomphoto");

                    b.Property<string>("NomProduit")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nomproduit");

                    b.Property<int>("StockMax")
                        .HasColumnType("integer")
                        .HasColumnName("stockmax");

                    b.Property<int>("StockMin")
                        .HasColumnType("integer")
                        .HasColumnName("stockmin");

                    b.Property<int>("StockReel")
                        .HasColumnType("integer")
                        .HasColumnName("stockreel");

                    b.Property<string>("UriPhoto")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("uriphoto");

                    b.Property<int>("idmarque")
                        .HasColumnType("integer");

                    b.Property<int>("idtypeproduit")
                        .HasColumnType("integer");

                    b.HasKey("IdProduit")
                        .HasName("pk_produit");

                    b.HasIndex("idmarque");

                    b.HasIndex("idtypeproduit");

                    b.ToTable("Produit");
                });

            modelBuilder.Entity("TD1Revisions.Models.EntityFramework.TypeProduit", b =>
                {
                    b.Property<int>("IdTypeProduit")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("idtypeproduit");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdTypeProduit"));

                    b.Property<string>("NomTypeProduit")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nomtypeproduit");

                    b.HasKey("IdTypeProduit")
                        .HasName("pk_typeproduit");

                    b.ToTable("TypeProduit");
                });

            modelBuilder.Entity("TD1Revisions.Models.EntityFramework.Produit", b =>
                {
                    b.HasOne("TD1Revisions.Models.EntityFramework.Marque", "IdMarqueNavigation")
                        .WithMany("Produits")
                        .HasForeignKey("idmarque")
                        .IsRequired()
                        .HasConstraintName("fk_produit_marque");

                    b.HasOne("TD1Revisions.Models.EntityFramework.TypeProduit", "IdTypeProduitNavigation")
                        .WithMany("Produits")
                        .HasForeignKey("idtypeproduit")
                        .IsRequired()
                        .HasConstraintName("fk_produit_typeproduit");

                    b.Navigation("IdMarqueNavigation");

                    b.Navigation("IdTypeProduitNavigation");
                });

            modelBuilder.Entity("TD1Revisions.Models.EntityFramework.Marque", b =>
                {
                    b.Navigation("Produits");
                });

            modelBuilder.Entity("TD1Revisions.Models.EntityFramework.TypeProduit", b =>
                {
                    b.Navigation("Produits");
                });
#pragma warning restore 612, 618
        }
    }
}
