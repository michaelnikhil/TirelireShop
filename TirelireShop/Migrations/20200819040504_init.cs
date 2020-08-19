using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TirelireShop.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IDclient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(maxLength: 50, nullable: false),
                    prenom = table.Column<string>(maxLength: 50, nullable: false),
                    email = table.Column<string>(maxLength: 50, nullable: false),
                    statutCompte = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IDclient);
                });

            migrationBuilder.CreateTable(
                name: "Couleur",
                columns: table => new
                {
                    IDcouleur = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    couleur = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couleur", x => x.IDcouleur);
                });

            migrationBuilder.CreateTable(
                name: "Fabricant",
                columns: table => new
                {
                    IDfabricant = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(maxLength: 50, nullable: false),
                    adresse = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricant", x => x.IDfabricant);
                });

            migrationBuilder.CreateTable(
                name: "StatutCommande",
                columns: table => new
                {
                    IDstatutCommande = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statutCommande = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatutCommande", x => x.IDstatutCommande);
                });

            migrationBuilder.CreateTable(
                name: "Produit",
                columns: table => new
                {
                    IDproduit = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(maxLength: 50, nullable: false),
                    hauteur = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    longueur = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    largeur = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    poids = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    capacite = table.Column<int>(nullable: false),
                    IDfabricant = table.Column<int>(nullable: false),
                    IDcouleur = table.Column<int>(nullable: false),
                    prix = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    descriptionFabricant = table.Column<string>(type: "text", nullable: false),
                    IDimage = table.Column<int>(nullable: false),
                    statutActivation = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produit", x => x.IDproduit);
                    table.ForeignKey(
                        name: "FK_Produit_Couleur",
                        column: x => x.IDcouleur,
                        principalTable: "Couleur",
                        principalColumn: "IDcouleur",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produit_Fabricant",
                        column: x => x.IDfabricant,
                        principalTable: "Fabricant",
                        principalColumn: "IDfabricant",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commande",
                columns: table => new
                {
                    IDcommande = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(nullable: false),
                    IDclient = table.Column<int>(nullable: false),
                    IDstatutCommande = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commande", x => x.IDcommande);
                    table.ForeignKey(
                        name: "FK_Commande_Client",
                        column: x => x.IDclient,
                        principalTable: "Client",
                        principalColumn: "IDclient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commande_StatutCommande",
                        column: x => x.IDstatutCommande,
                        principalTable: "StatutCommande",
                        principalColumn: "IDstatutCommande",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Avis",
                columns: table => new
                {
                    IDavis = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contenu = table.Column<string>(type: "text", nullable: false),
                    statut = table.Column<bool>(nullable: false),
                    IDclient = table.Column<int>(nullable: false),
                    IDproduit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avis", x => x.IDavis);
                    table.ForeignKey(
                        name: "FK_Avis_Client",
                        column: x => x.IDclient,
                        principalTable: "Client",
                        principalColumn: "IDclient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Avis_Produit",
                        column: x => x.IDproduit,
                        principalTable: "Produit",
                        principalColumn: "IDproduit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    IDimage = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cheminAcces = table.Column<string>(maxLength: 100, nullable: false),
                    IDproduit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.IDimage);
                    table.ForeignKey(
                        name: "FK_Image_Produit",
                        column: x => x.IDproduit,
                        principalTable: "Produit",
                        principalColumn: "IDproduit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetailsCommande",
                columns: table => new
                {
                    IDdetailsCommande = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDcommande = table.Column<int>(nullable: false),
                    IDproduit = table.Column<int>(nullable: false),
                    quantite = table.Column<int>(nullable: false),
                    prix = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsCommande", x => x.IDdetailsCommande);
                    table.ForeignKey(
                        name: "FK_DetailsCommande_Commande",
                        column: x => x.IDcommande,
                        principalTable: "Commande",
                        principalColumn: "IDcommande",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailsCommande_Produit",
                        column: x => x.IDproduit,
                        principalTable: "Produit",
                        principalColumn: "IDproduit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avis_IDclient",
                table: "Avis",
                column: "IDclient");

            migrationBuilder.CreateIndex(
                name: "IX_Avis_IDproduit",
                table: "Avis",
                column: "IDproduit");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_IDclient",
                table: "Commande",
                column: "IDclient");

            migrationBuilder.CreateIndex(
                name: "IX_Commande_IDstatutCommande",
                table: "Commande",
                column: "IDstatutCommande");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsCommande_IDcommande",
                table: "DetailsCommande",
                column: "IDcommande");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsCommande_IDproduit",
                table: "DetailsCommande",
                column: "IDproduit");

            migrationBuilder.CreateIndex(
                name: "IX_Image_IDproduit",
                table: "Image",
                column: "IDproduit");

            migrationBuilder.CreateIndex(
                name: "IX_Produit_IDcouleur",
                table: "Produit",
                column: "IDcouleur");

            migrationBuilder.CreateIndex(
                name: "IX_Produit_IDfabricant",
                table: "Produit",
                column: "IDfabricant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avis");

            migrationBuilder.DropTable(
                name: "DetailsCommande");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Commande");

            migrationBuilder.DropTable(
                name: "Produit");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "StatutCommande");

            migrationBuilder.DropTable(
                name: "Couleur");

            migrationBuilder.DropTable(
                name: "Fabricant");
        }
    }
}
