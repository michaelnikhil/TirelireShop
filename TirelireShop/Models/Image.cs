using System;
using System.Collections.Generic;

namespace TirelireShop
{
    public partial class Image
    {
        public int Idimage { get; set; }
        public string CheminAcces { get; set; }
        public int Idproduit { get; set; }

        public virtual Produit IdproduitNavigation { get; set; }
    }
}
