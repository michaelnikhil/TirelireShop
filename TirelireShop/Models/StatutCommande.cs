using System;
using System.Collections.Generic;

namespace TirelireShop
{
    public partial class StatutCommande
    {
        public StatutCommande()
        {
            Commande = new HashSet<Commande>();
        }

        public int IdstatutCommande { get; set; }
        public string StatutCommande1 { get; set; }

        public virtual ICollection<Commande> Commande { get; set; }
    }
}
