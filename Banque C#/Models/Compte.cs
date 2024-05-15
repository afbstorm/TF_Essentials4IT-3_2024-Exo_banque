using Banque_C_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque_C_.Models
{
    internal class Compte
    {
        public string Numero {  get; set; }
        public double Solde { get; private set; }
        public Personne Titulaire { get; set; }

        // Création d'une méthode qui effectuera un retrait VIA sa surcharge du même nom
        public virtual void Retrait(double montant)
        {
            Retrait(montant, 0.0);
        }

        // Création de la méthode surcharge de Retrait qui va effectuer toute la logique
        public void Retrait(double montant, double ligneDeCredit)
        {
            if (montant <= 0) return;

            // -ligneDeCredit vérifie si le Solde - montant est inférieur a la limite NEGATIVE du crédit autorisé
            if (Solde - montant < -ligneDeCredit) return;

            Console.WriteLine($"Retrait en cours : Compte n°{Numero} de {montant}");
            Solde -= montant;
        }

        public void Depot(double montant)
        {
            if (montant <= 0) return;
            
            Console.WriteLine($"Dépot en cours : Compte n°{Numero} de {montant}");
            Solde += montant;
        }

        public static double operator +(double solde, Compte compte)
        {
            return solde + (compte.Solde > 0 ? compte.Solde : 0);
        }
    }
}


