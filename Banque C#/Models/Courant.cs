namespace Banque_C_.Models;

internal class Courant : Compte
{
    private double _ligneDeCredit;
    public double LigneDeCredit
    {
        get { return _ligneDeCredit; }
        set
        {
            if (value >= 0)
            {
                _ligneDeCredit = value;
            }
        }
    }

    public override void Retrait(double montant)
    {
        Retrait(montant, LigneDeCredit);
    }
}
