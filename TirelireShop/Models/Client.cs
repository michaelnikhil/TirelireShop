using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace TirelireShop
{
    public partial class Client : IdentityUser
    {
        public Client()
        {
            Avis = new HashSet<Avis>();
            Commande = new HashSet<Commande>();
        }

        public int Idclient { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public bool StatutCompte { get; set; }

        public virtual ICollection<Avis> Avis { get; set; }
        public virtual ICollection<Commande> Commande { get; set; }
    }
}
