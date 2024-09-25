using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TD1Revisions.Migrations
{
    /// <inheritdoc />
    public partial class CreationBDDProduits2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_produit_marque",
                table: "Produit");

            migrationBuilder.DropForeignKey(
                name: "fk_produit_typeproduit",
                table: "Produit");

            migrationBuilder.DropIndex(
                name: "IX_Produit_idMarque",
                table: "Produit");

            migrationBuilder.DropIndex(
                name: "IX_Produit_idTypeProduit",
                table: "Produit");

            migrationBuilder.DropColumn(
                name: "idMarque",
                table: "Produit");

            migrationBuilder.DropColumn(
                name: "idTypeProduit",
                table: "Produit");

            migrationBuilder.RenameColumn(
                name: "uriPhoto",
                table: "Produit",
                newName: "uriphoto");

            migrationBuilder.CreateIndex(
                name: "IX_Produit_idmarque",
                table: "Produit",
                column: "idmarque");

            migrationBuilder.CreateIndex(
                name: "IX_Produit_idtypeproduit",
                table: "Produit",
                column: "idtypeproduit");

            migrationBuilder.AddForeignKey(
                name: "fk_produit_marque",
                table: "Produit",
                column: "idmarque",
                principalTable: "Marque",
                principalColumn: "idmarque");

            migrationBuilder.AddForeignKey(
                name: "fk_produit_typeproduit",
                table: "Produit",
                column: "idtypeproduit",
                principalTable: "TypeProduit",
                principalColumn: "idtypeproduit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_produit_marque",
                table: "Produit");

            migrationBuilder.DropForeignKey(
                name: "fk_produit_typeproduit",
                table: "Produit");

            migrationBuilder.DropIndex(
                name: "IX_Produit_idmarque",
                table: "Produit");

            migrationBuilder.DropIndex(
                name: "IX_Produit_idtypeproduit",
                table: "Produit");

            migrationBuilder.RenameColumn(
                name: "uriphoto",
                table: "Produit",
                newName: "uriPhoto");

            migrationBuilder.AddColumn<int>(
                name: "idMarque",
                table: "Produit",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idTypeProduit",
                table: "Produit",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produit_idMarque",
                table: "Produit",
                column: "idMarque");

            migrationBuilder.CreateIndex(
                name: "IX_Produit_idTypeProduit",
                table: "Produit",
                column: "idTypeProduit");

            migrationBuilder.AddForeignKey(
                name: "fk_produit_marque",
                table: "Produit",
                column: "idMarque",
                principalTable: "Marque",
                principalColumn: "idmarque");

            migrationBuilder.AddForeignKey(
                name: "fk_produit_typeproduit",
                table: "Produit",
                column: "idTypeProduit",
                principalTable: "TypeProduit",
                principalColumn: "idtypeproduit");
        }
    }
}
