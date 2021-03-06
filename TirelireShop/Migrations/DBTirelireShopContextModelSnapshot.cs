﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TirelireShop;

namespace TirelireShop.Migrations
{
    [DbContext(typeof(DBTirelireShopContext))]
    partial class DBTirelireShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TirelireShop.Avis", b =>
                {
                    b.Property<int>("Idavis")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDavis")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contenu")
                        .IsRequired()
                        .HasColumnName("contenu")
                        .HasColumnType("text");

                    b.Property<int>("Idclient")
                        .HasColumnName("IDclient")
                        .HasColumnType("int");

                    b.Property<int>("Idproduit")
                        .HasColumnName("IDproduit")
                        .HasColumnType("int");

                    b.Property<bool>("Statut")
                        .HasColumnName("statut")
                        .HasColumnType("bit");

                    b.HasKey("Idavis");

                    b.HasIndex("Idclient");

                    b.HasIndex("Idproduit");

                    b.ToTable("Avis");
                });

            modelBuilder.Entity("TirelireShop.Client", b =>
                {
                    b.Property<int>("Idclient")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDclient")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnName("nom")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnName("prenom")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("StatutCompte")
                        .HasColumnName("statutCompte")
                        .HasColumnType("bit");

                    b.HasKey("Idclient");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("TirelireShop.Commande", b =>
                {
                    b.Property<int>("Idcommande")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDcommande")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnName("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Idclient")
                        .HasColumnName("IDclient")
                        .HasColumnType("int");

                    b.Property<int>("IdstatutCommande")
                        .HasColumnName("IDstatutCommande")
                        .HasColumnType("int");

                    b.HasKey("Idcommande");

                    b.HasIndex("Idclient");

                    b.HasIndex("IdstatutCommande");

                    b.ToTable("Commande");
                });

            modelBuilder.Entity("TirelireShop.Couleur", b =>
                {
                    b.Property<int>("Idcouleur")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDcouleur")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Couleur1")
                        .IsRequired()
                        .HasColumnName("couleur")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Idcouleur");

                    b.ToTable("Couleur");
                });

            modelBuilder.Entity("TirelireShop.DetailsCommande", b =>
                {
                    b.Property<int>("IddetailsCommande")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDdetailsCommande")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Idcommande")
                        .HasColumnName("IDcommande")
                        .HasColumnType("int");

                    b.Property<int>("Idproduit")
                        .HasColumnName("IDproduit")
                        .HasColumnType("int");

                    b.Property<decimal>("Prix")
                        .HasColumnName("prix")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Quantite")
                        .HasColumnName("quantite")
                        .HasColumnType("int");

                    b.HasKey("IddetailsCommande");

                    b.HasIndex("Idcommande");

                    b.HasIndex("Idproduit");

                    b.ToTable("DetailsCommande");
                });

            modelBuilder.Entity("TirelireShop.Fabricant", b =>
                {
                    b.Property<int>("Idfabricant")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDfabricant")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnName("adresse")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnName("nom")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Idfabricant");

                    b.ToTable("Fabricant");
                });

            modelBuilder.Entity("TirelireShop.Image", b =>
                {
                    b.Property<int>("Idimage")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDimage")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CheminAcces")
                        .IsRequired()
                        .HasColumnName("cheminAcces")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Idproduit")
                        .HasColumnName("IDproduit")
                        .HasColumnType("int");

                    b.HasKey("Idimage");

                    b.HasIndex("Idproduit");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("TirelireShop.Produit", b =>
                {
                    b.Property<int>("Idproduit")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDproduit")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacite")
                        .HasColumnName("capacite")
                        .HasColumnType("int");

                    b.Property<string>("DescriptionFabricant")
                        .IsRequired()
                        .HasColumnName("descriptionFabricant")
                        .HasColumnType("text");

                    b.Property<decimal>("Hauteur")
                        .HasColumnName("hauteur")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Idcouleur")
                        .HasColumnName("IDcouleur")
                        .HasColumnType("int");

                    b.Property<int>("Idfabricant")
                        .HasColumnName("IDfabricant")
                        .HasColumnType("int");

                    b.Property<int>("Idimage")
                        .HasColumnName("IDimage")
                        .HasColumnType("int");

                    b.Property<decimal>("Largeur")
                        .HasColumnName("largeur")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Longueur")
                        .HasColumnName("longueur")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnName("nom")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("Poids")
                        .HasColumnName("poids")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Prix")
                        .HasColumnName("prix")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<bool>("StatutActivation")
                        .HasColumnName("statutActivation")
                        .HasColumnType("bit");

                    b.HasKey("Idproduit");

                    b.HasIndex("Idcouleur");

                    b.HasIndex("Idfabricant");

                    b.ToTable("Produit");
                });

            modelBuilder.Entity("TirelireShop.StatutCommande", b =>
                {
                    b.Property<int>("IdstatutCommande")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDstatutCommande")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatutCommande1")
                        .IsRequired()
                        .HasColumnName("statutCommande")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("IdstatutCommande");

                    b.ToTable("StatutCommande");
                });

            modelBuilder.Entity("TirelireShop.Avis", b =>
                {
                    b.HasOne("TirelireShop.Client", "IdclientNavigation")
                        .WithMany("Avis")
                        .HasForeignKey("Idclient")
                        .HasConstraintName("FK_Avis_Client")
                        .IsRequired();

                    b.HasOne("TirelireShop.Produit", "IdproduitNavigation")
                        .WithMany("Avis")
                        .HasForeignKey("Idproduit")
                        .HasConstraintName("FK_Avis_Produit")
                        .IsRequired();
                });

            modelBuilder.Entity("TirelireShop.Commande", b =>
                {
                    b.HasOne("TirelireShop.Client", "IdclientNavigation")
                        .WithMany("Commande")
                        .HasForeignKey("Idclient")
                        .HasConstraintName("FK_Commande_Client")
                        .IsRequired();

                    b.HasOne("TirelireShop.StatutCommande", "IdstatutCommandeNavigation")
                        .WithMany("Commande")
                        .HasForeignKey("IdstatutCommande")
                        .HasConstraintName("FK_Commande_StatutCommande")
                        .IsRequired();
                });

            modelBuilder.Entity("TirelireShop.DetailsCommande", b =>
                {
                    b.HasOne("TirelireShop.Commande", "IdcommandeNavigation")
                        .WithMany("DetailsCommande")
                        .HasForeignKey("Idcommande")
                        .HasConstraintName("FK_DetailsCommande_Commande")
                        .IsRequired();

                    b.HasOne("TirelireShop.Produit", "IdproduitNavigation")
                        .WithMany("DetailsCommande")
                        .HasForeignKey("Idproduit")
                        .HasConstraintName("FK_DetailsCommande_Produit")
                        .IsRequired();
                });

            modelBuilder.Entity("TirelireShop.Image", b =>
                {
                    b.HasOne("TirelireShop.Produit", "IdproduitNavigation")
                        .WithMany("Image")
                        .HasForeignKey("Idproduit")
                        .HasConstraintName("FK_Image_Produit")
                        .IsRequired();
                });

            modelBuilder.Entity("TirelireShop.Produit", b =>
                {
                    b.HasOne("TirelireShop.Couleur", "IdcouleurNavigation")
                        .WithMany("Produit")
                        .HasForeignKey("Idcouleur")
                        .HasConstraintName("FK_Produit_Couleur")
                        .IsRequired();

                    b.HasOne("TirelireShop.Fabricant", "IdfabricantNavigation")
                        .WithMany("Produit")
                        .HasForeignKey("Idfabricant")
                        .HasConstraintName("FK_Produit_Fabricant")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
