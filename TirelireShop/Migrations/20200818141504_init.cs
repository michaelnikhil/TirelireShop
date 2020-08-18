using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TirelireShop.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    IDclient = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    email = table.Column<string>(maxLength: 50, nullable: false),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    nom = table.Column<string>(maxLength: 50, nullable: false),
                    prenom = table.Column<string>(maxLength: 50, nullable: false),
                    statutCompte = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.IDclient);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "IDclient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "IDclient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "IDclient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "IDclient",
                        onDelete: ReferentialAction.Cascade);
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
                    IDclient = table.Column<string>(nullable: true),
                    IDstatutCommande = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commande", x => x.IDcommande);
                    table.ForeignKey(
                        name: "FK_Commande_Client",
                        column: x => x.IDclient,
                        principalTable: "AspNetUsers",
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
                    IDclient = table.Column<string>(nullable: true),
                    IDproduit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avis", x => x.IDavis);
                    table.ForeignKey(
                        name: "FK_Avis_Client",
                        column: x => x.IDclient,
                        principalTable: "AspNetUsers",
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Avis");

            migrationBuilder.DropTable(
                name: "DetailsCommande");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Commande");

            migrationBuilder.DropTable(
                name: "Produit");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "StatutCommande");

            migrationBuilder.DropTable(
                name: "Couleur");

            migrationBuilder.DropTable(
                name: "Fabricant");
        }
    }
}
