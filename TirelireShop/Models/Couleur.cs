using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TirelireShop
{
    public partial class Couleur
    {
        public Couleur()
        {
            Produit = new HashSet<Produit>();
        }

        public int Idcouleur { get; set; }

        [DisplayName("Couleur")]
        public string Couleur1 { get; set; }
        
        public virtual ICollection<Produit> Produit { get; set; }
    }
}
