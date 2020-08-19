using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TirelireShop.ViewModels
{
    public class SessionStateViewModel
    {
        public string CustomerName { get; set; }
        public List<DetailsCommande> Commandes { get; set; }
    }
}
