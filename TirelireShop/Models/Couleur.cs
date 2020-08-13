using System;
using System.Collections.Generic;

namespace TirelireShop
{
    public partial class Couleur
    {
        public Couleur()
        {
            Produit = new HashSet<Produit>();
        }

        public int Idcouleur { get; set; }
        public string Couleur1 { get; set; }

        public virtual ICollection<Produit> Produit { get; set; }
    }
}
