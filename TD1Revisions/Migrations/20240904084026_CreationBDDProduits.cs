using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TD1Revisions.Migrations
{
    /// <inheritdoc />
    public partial class CreationBDDProduits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marque",
                columns: table => new
                {
                    idmarque = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nommarque = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_marque", x => x.idmarque);
                });

            migrationBuilder.CreateTable(
                name: "TypeProduit",
                columns: table => new
                {
                    idtypeproduit = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomtypeproduit = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_typeproduit", x => x.idtypeproduit);
                });

            migrationBuilder.CreateTable(
                name: "Produit",
                columns: table => new
                {
                    idproduit = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomproduit = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    nomphoto = table.Column<string>(type: "text", nullable: false),
                    uriPhoto = table.Column<string>(type: "text", nullable: false),
                    idtypeproduit = table.Column<int>(type: "integer", nullable: false),
                    idmarque = table.Column<int>(type: "integer", nullable: false),
                    stockreel = table.Column<int>(type: "integer", nullable: false),
                    stockmin = table.Column<int>(type: "integer", nullable: false),
                    stockmax = table.Column<int>(type: "integer", nullable: false),
                    idMarque = table.Column<int>(type: "integer", nullable: false),
                    idTypeProduit = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_produit", x => x.idproduit);
                    table.ForeignKey(
                        name: "fk_produit_marque",
                        column: x => x.idMarque,
                        principalTable: "Marque",
                        principalColumn: "idmarque");
                    table.ForeignKey(
                        name: "fk_produit_typeproduit",
                        column: x => x.idTypeProduit,
                        principalTable: "TypeProduit",
                        principalColumn: "idtypeproduit");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produit_idMarque",
                table: "Produit",
                column: "idMarque");

            migrationBuilder.CreateIndex(
                name: "IX_Produit_idTypeProduit",
                table: "Produit",
                column: "idTypeProduit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produit");

            migrationBuilder.DropTable(
                name: "Marque");

            migrationBuilder.DropTable(
                name: "TypeProduit");
        }
    }
}
