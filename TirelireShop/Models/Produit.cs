using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TirelireShop
{
    public partial class Produit
    {
        public Produit()
        {
            Avis = new HashSet<Avis>();
            DetailsCommande = new HashSet<DetailsCommande>();
            Image = new HashSet<Image>();
        }

        public int Idproduit { get; set; }
        public string Nom { get; set; }
        public decimal Hauteur { get; set; }
        public decimal Longueur { get; set; }
        public decimal Largeur { get; set; }
        public decimal Poids { get; set; }
        public int Capacite { get; set; }
        [DisplayName("Fabricant")]
        public int Idfabricant { get; set; }
        [DisplayName("Couleur")]
        public int Idcouleur { get; set; }
        public decimal Prix { get; set; }
        [DisplayName("Description par le fabricant")]
        public string DescriptionFabricant { get; set; }
        public int Idimage { get; set; }
        [DisplayName("A la vente")]
        public bool StatutActivation { get; set; }

        [DisplayName("Couleur")]
        public virtual Couleur IdcouleurNavigation { get; set; }
        [DisplayName("Fabricant")]
        public virtual Fabricant IdfabricantNavigation { get; set; }




        public virtual ICollection<Avis> Avis { get; set; }
        public virtual ICollection<DetailsCommande> DetailsCommande { get; set; }
        public virtual ICollection<Image> Image { get; set; }
    }
}
