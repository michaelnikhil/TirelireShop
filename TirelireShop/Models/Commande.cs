using System;
using System.Collections.Generic;

namespace TirelireShop
{
    public partial class Commande
    {
        public Commande()
        {
            DetailsCommande = new HashSet<DetailsCommande>();
        }

        public int Idcommande { get; set; }
        public DateTime Date { get; set; }
        //public int Idclient { get; set; }
        public string Idclient { get; set; }
        public int IdstatutCommande { get; set; }

        public virtual Client IdclientNavigation { get; set; }
        public virtual StatutCommande IdstatutCommandeNavigation { get; set; }
        public virtual ICollection<DetailsCommande> DetailsCommande { get; set; }
    }
}
