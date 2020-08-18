using System;
using System.Collections.Generic;

namespace TirelireShop
{
    public partial class Avis
    {
        public int Idavis { get; set; }
        public string Contenu { get; set; }
        public bool Statut { get; set; }
        //public int Idclient { get; set; }
        public string Idclient { get; set; }
        public int Idproduit { get; set; }

        public virtual Client IdclientNavigation { get; set; }
        public virtual Produit IdproduitNavigation { get; set; }
    }
}
