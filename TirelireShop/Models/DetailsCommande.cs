﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TirelireShop
{
    public partial class DetailsCommande
    {
        public int IddetailsCommande { get; set; }
        public int Idcommande { get; set; }
        public int Idproduit { get; set; }
        [DisplayName("Quantité")]
        public int Quantite { get; set; }
        public decimal Prix { get; set; }

        public virtual Commande IdcommandeNavigation { get; set; }
        public virtual Produit IdproduitNavigation { get; set; }
    }
}
