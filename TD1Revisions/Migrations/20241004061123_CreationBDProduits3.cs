using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TD1Revisions.Migrations
{
    /// <inheritdoc />
    public partial class CreationBDProduits3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "marque",
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
                name: "typeproduit",
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
                name: "produit",
                columns: table => new
                {
                    idproduit = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomproduit = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    nomphoto = table.Column<string>(type: "text", nullable: true),
                    uriphoto = table.Column<string>(type: "text", nullable: true),
                    stockreel = table.Column<int>(type: "integer", nullable: false),
                    stockmin = table.Column<int>(type: "integer", nullable: false),
                    stockmax = table.Column<int>(type: "integer", nullable: false),
                    idmarque = table.Column<int>(type: "integer", nullable: false),
                    idtypeproduit = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_produit", x => x.idproduit);
                    table.ForeignKey(
                        name: "fk_produit_marque",
                        column: x => x.idmarque,
                        principalTable: "marque",
                        principalColumn: "idmarque");
                    table.ForeignKey(
                        name: "fk_produit_typeproduit",
                        column: x => x.idtypeproduit,
                        principalTable: "typeproduit",
                        principalColumn: "idtypeproduit");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produit_idmarque",
                table: "produit",
                column: "idmarque");

            migrationBuilder.CreateIndex(
                name: "IX_Produit_idtypeproduit",
                table: "produit",
                column: "idtypeproduit");


            migrationBuilder.Sql("INSERT INTO marque(nommarque) Values('Prada'),('Aliexpress'),('Dior'),('LV')");
            migrationBuilder.Sql("INSERT INTO typeProduit(nomtypeproduit) Values('chemise'),('parfum'),('lunettes'),('bracelet')");
            migrationBuilder.Sql("INSERT INTO produit(nomproduit, description, nomphoto, uriphoto, idtypeproduit, idmarque, stockreel, stockmin, stockmax) " +
                "Values('chemise ultra xxxxxs','chemise tres petite parda','chemisepetite','chemisepetite.png',1,1,17,5,30)," +
                "('bracelet joli','bracelet rose avec une pierre','braceletrose', NULL ,4,2,54,0,100)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produit");

            migrationBuilder.DropTable(
                name: "marque");

            migrationBuilder.DropTable(
                name: "typeproduit");
        }
    }
}
