using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace TirelireShop
{
    public partial class DBTirelireShopContext : DbContext
    {
        public DBTirelireShopContext()
        {
        }

        public DBTirelireShopContext(DbContextOptions<DBTirelireShopContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Avis> Avis { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Commande> Commande { get; set; }
        public virtual DbSet<Couleur> Couleur { get; set; }
        public virtual DbSet<DetailsCommande> DetailsCommande { get; set; }
        public virtual DbSet<Fabricant> Fabricant { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Produit> Produit { get; set; }
        public virtual DbSet<StatutCommande> StatutCommande { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avis>(entity =>
            {
                entity.HasKey(e => e.Idavis);

                entity.Property(e => e.Idavis).HasColumnName("IDavis");

                entity.Property(e => e.Contenu)
                    .IsRequired()
                    .HasColumnName("contenu")
                    .HasColumnType("text");

                entity.Property(e => e.Idclient).HasColumnName("IDclient");

                entity.Property(e => e.Idproduit).HasColumnName("IDproduit");

                entity.Property(e => e.Statut).HasColumnName("statut");

                entity.HasOne(d => d.IdclientNavigation)
                    .WithMany(p => p.Avis)
                    .HasForeignKey(d => d.Idclient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Avis_Client");

                entity.HasOne(d => d.IdproduitNavigation)
                    .WithMany(p => p.Avis)
                    .HasForeignKey(d => d.Idproduit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Avis_Produit");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Idclient);

                entity.Property(e => e.Idclient).HasColumnName("IDclient");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(50);

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasColumnName("prenom")
                    .HasMaxLength(50);

                entity.Property(e => e.StatutCompte).HasColumnName("statutCompte");
            });

            modelBuilder.Entity<Commande>(entity =>
            {
                entity.HasKey(e => e.Idcommande);

                entity.Property(e => e.Idcommande).HasColumnName("IDcommande");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Idclient).HasColumnName("IDclient");

                entity.Property(e => e.IdstatutCommande).HasColumnName("IDstatutCommande");

                entity.HasOne(d => d.IdclientNavigation)
                    .WithMany(p => p.Commande)
                    .HasForeignKey(d => d.Idclient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Commande_Client");

                entity.HasOne(d => d.IdstatutCommandeNavigation)
                    .WithMany(p => p.Commande)
                    .HasForeignKey(d => d.IdstatutCommande)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Commande_StatutCommande");
            });

            modelBuilder.Entity<Couleur>(entity =>
            {
                entity.HasKey(e => e.Idcouleur);

                entity.Property(e => e.Idcouleur).HasColumnName("IDcouleur");

                entity.Property(e => e.Couleur1)
                    .IsRequired()
                    .HasColumnName("couleur")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DetailsCommande>(entity =>
            {
                entity.HasKey(e => e.IddetailsCommande);

                entity.Property(e => e.IddetailsCommande).HasColumnName("IDdetailsCommande");

                entity.Property(e => e.Idcommande).HasColumnName("IDcommande");

                entity.Property(e => e.Idproduit).HasColumnName("IDproduit");

                entity.Property(e => e.Prix)
                    .HasColumnName("prix")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Quantite).HasColumnName("quantite");

                entity.HasOne(d => d.IdcommandeNavigation)
                    .WithMany(p => p.DetailsCommande)
                    .HasForeignKey(d => d.Idcommande)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetailsCommande_Commande");

                entity.HasOne(d => d.IdproduitNavigation)
                    .WithMany(p => p.DetailsCommande)
                    .HasForeignKey(d => d.Idproduit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetailsCommande_Produit");
            });

            modelBuilder.Entity<Fabricant>(entity =>
            {
                entity.HasKey(e => e.Idfabricant);

                entity.Property(e => e.Idfabricant).HasColumnName("IDfabricant");

                entity.Property(e => e.Adresse)
                    .IsRequired()
                    .HasColumnName("adresse")
                    .HasMaxLength(50);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.Idimage);

                entity.Property(e => e.Idimage).HasColumnName("IDimage");

                entity.Property(e => e.CheminAcces)
                    .IsRequired()
                    .HasColumnName("cheminAcces")
                    .HasMaxLength(100);

                entity.Property(e => e.Idproduit).HasColumnName("IDproduit");

                entity.HasOne(d => d.IdproduitNavigation)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.Idproduit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Image_Produit");
            });

            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasKey(e => e.Idproduit);

                entity.Property(e => e.Idproduit).HasColumnName("IDproduit");

                entity.Property(e => e.Capacite).HasColumnName("capacite");

                entity.Property(e => e.DescriptionFabricant)
                    .IsRequired()
                    .HasColumnName("descriptionFabricant")
                    .HasColumnType("text");

                entity.Property(e => e.Hauteur)
                    .HasColumnName("hauteur")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Idcouleur).HasColumnName("IDcouleur");

                entity.Property(e => e.Idfabricant).HasColumnName("IDfabricant");

                entity.Property(e => e.Idimage).HasColumnName("IDimage");

                entity.Property(e => e.Largeur)
                    .HasColumnName("largeur")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Longueur)
                    .HasColumnName("longueur")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasMaxLength(50);

                entity.Property(e => e.Poids)
                    .HasColumnName("poids")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Prix)
                    .HasColumnName("prix")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StatutActivation).HasColumnName("statutActivation");

                entity.HasOne(d => d.IdcouleurNavigation)
                    .WithMany(p => p.Produit)
                    .HasForeignKey(d => d.Idcouleur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produit_Couleur");

                entity.HasOne(d => d.IdfabricantNavigation)
                    .WithMany(p => p.Produit)
                    .HasForeignKey(d => d.Idfabricant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Produit_Fabricant");
            });

            modelBuilder.Entity<StatutCommande>(entity =>
            {
                entity.HasKey(e => e.IdstatutCommande);

                entity.Property(e => e.IdstatutCommande).HasColumnName("IDstatutCommande");

                entity.Property(e => e.StatutCommande1)
                    .IsRequired()
                    .HasColumnName("statutCommande")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
