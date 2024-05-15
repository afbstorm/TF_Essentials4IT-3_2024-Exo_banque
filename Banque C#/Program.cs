using Banque_C_.Models;

Console.OutputEncoding = System.Text.Encoding.Unicode;

Personne p1 = new Personne();
p1.Nom = "Legrain";
p1.Prenom = "Samuel";
p1.DateNaiss = new DateTime(1987, 9, 27);

Personne p2 = new Personne() { 
    Nom = "Morre",
    Prenom = "Thierry",
    DateNaiss = new DateTime(1970,1,1)
};

Console.WriteLine($"Identité : {p1.Nom} {p1.Prenom}, né le {p1.DateNaiss}");
Console.WriteLine($"Identité : {p2.Nom} {p2.Prenom}, né le {p2.DateNaiss}");

Courant c1 = new Courant() { 
    Numero = "BE01",
    LigneDeCredit = 200,
    Titulaire = new Personne()
    {
        Nom = "Person",
        Prenom = "Michael",
        DateNaiss = new DateTime(1980,1,1)
    }
};

c1.Depot(20_000);
Console.WriteLine($"Le compte courant : {c1.Numero}\n" +
    $"du titulaire : {c1.Titulaire.Nom} {c1.Titulaire.Prenom}\n" +
    $"né le {c1.Titulaire.DateNaiss}\n" + 
    $"a comme solde {c1.Solde} € avec une ligne de credit de {c1.LigneDeCredit} €.");
c1.Retrait(20_200);

Courant c2 = new Courant()
{
    Numero = "BE02",
    LigneDeCredit = 0,
    Titulaire = p1
};
c2.Depot(1_500);
Console.WriteLine($"Le compte courant : {c2.Numero}\n" +
    $"du titulaire : {c2.Titulaire.Nom} {c2.Titulaire.Prenom}\n" +
    $"né le {c2.Titulaire.DateNaiss}\n" +
    $"a comme solde {c2.Solde} € avec une ligne de credit de {c2.LigneDeCredit} €.");

Courant c3 = new Courant()
{
    Numero = "BE03",
    LigneDeCredit = 100,
    Titulaire = p1
};
c3.Depot(2_500);
Console.WriteLine($"Le compte courant : {c3.Numero}\n" +
    $"du titulaire : {c3.Titulaire.Nom} {c3.Titulaire.Prenom}\n" +
    $"né le {c3.Titulaire.DateNaiss}\n" +
    $"a comme solde {c3.Solde} € avec une ligne de credit de {c3.LigneDeCredit} €.");

Banque b1 = new Banque() { Nom = "AuBonBénéfice!"};
b1.Ajouter(c1);
b1.Ajouter(c2);
b1.Ajouter(c3);

Courant selected_account = b1["BE02"];
if (selected_account != null)
{
    selected_account.Depot(15_000);
}
//b1["BE02"]?.Depot(15_000);

Console.WriteLine($"Le compte courant : {c2.Numero}\n" +
    $"du titulaire : {c2.Titulaire.Nom} {c2.Titulaire.Prenom}\n" +
    $"né le {c2.Titulaire.DateNaiss}\n" +
    $"a comme solde {c2.Solde} € avec une ligne de credit de {c2.LigneDeCredit} €.");

Console.WriteLine(" ---- Calcul des avoirs ---- ");

Console.WriteLine($"Le total des comptes de {p1.Nom} {p1.Prenom} est de {b1.AvoirDesComptes(p1)}");
Console.WriteLine($"Le total des comptes de {p2.Nom} {p2.Prenom} est de {b1.AvoirDesComptes(p2)}");
Console.WriteLine($"Le total des comptes de {c1.Titulaire.Nom} {c1.Titulaire.Prenom} est de {b1.AvoirDesComptes(c1.Titulaire)}");

Console.WriteLine(" ---- Création des comptes épargnes ---- ");

Epargne E1 = new Epargne { Titulaire = p1, Numero = "001" };
Epargne E2 = new Epargne { Titulaire = p2, Numero = "999" };

E1.Depot(200);
E1.Retrait(100);

E2.Depot(1500);
E2.Retrait(500);