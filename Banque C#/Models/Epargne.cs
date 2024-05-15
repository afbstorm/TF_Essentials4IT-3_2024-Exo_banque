using Banque_C_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque_C_.Models
{
    internal class Epargne : Compte
    {
    
        public DateTime DateDernierRetrait { get; set; }

        public override void Retrait(double montant)
        {
            var AncienSolde = Solde;
            base.Retrait(montant);

            if (Solde != AncienSolde)
            {
                DateDernierRetrait = DateTime.Now;
            }
        }
    }
}
