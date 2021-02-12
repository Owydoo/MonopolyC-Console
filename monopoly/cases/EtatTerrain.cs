using System;
using System.Collections.Generic;
using System.Text;

namespace monopoly
{
    public abstract class EtatTerrain
    {
        public abstract void PayerLoyer(Joueur j, Terrain terrain);
        public abstract void Construire(Joueur j, Terrain terrain);
        public abstract void AcheterTerrain(Joueur j, Terrain terrain);
        public abstract void StopperSur(Joueur j, Terrain terrain);
    }

    public class EtatAchetable : EtatTerrain
    {
        public EtatAchetable() { }
        public override void PayerLoyer(Joueur j, Terrain terrain)
        {

        }
        public override void Construire(Joueur j, Terrain terrain)
        {

        }
        public override void AcheterTerrain(Joueur j, Terrain terrain)
        {

        }
        public override void StopperSur(Joueur j, Terrain terrain)
        {
            Console.WriteLine(terrain.ToString());
            Console.WriteLine("Voulez-vous acheter ce terrain ?[Y/N]");
            string choice = Console.ReadLine().ToLower();
            if (choice == "y")
            {
                //TODO:Vérifier les sous
                bool achatPossible = j.VerifAchatPossible(terrain.prixDepart);
                if (achatPossible)
                {
                    terrain.EnregistreAcheteur(j);
                    j.DebiteCompte(terrain.prixDepart);
                    Console.WriteLine($"Il vous reste {j.argent} sur votre compte.");
                }
                else
                {
                    Console.WriteLine("Vous ne pouvez pas acheter cette propriété.");
                }

            }
            else
            {
                Console.WriteLine("Lol le nullos !! C'est pas tres startup nation ca...");
            }
        }
        public override string ToString()
        {
            return "ACHETABLE";
        }

    }

    public class EtatAchete : EtatTerrain
    {
        public EtatAchete() { }
        public override void PayerLoyer(Joueur j, Terrain terrain)
        {

        }
        public override void Construire(Joueur j, Terrain terrain)
        {

        }
        public override void AcheterTerrain(Joueur j, Terrain terrain)
        {

        }
        public override void StopperSur(Joueur j, Terrain terrain)
        {
            if (j != terrain.proprietaire)
            {
                Console.WriteLine($"Vous êtes tombés sur {terrain.nom} qui appartient à {terrain.proprietaire.nom}");

                int loyer = terrain.CalculerLoyer();

                //PayerLoyer(luc, montant)
                j.PayerLoyer(terrain.proprietaire, loyer);
            }
            else
            {
                Console.WriteLine($"Vous êtes tombés sur {terrain.nom} qui est votre propriété.");
            }
        }
        public override string ToString()
        {
            return "ACHETE";
        }

    }

    public class EtatConstructible : EtatTerrain
    {
        public EtatConstructible() { }
        public override void PayerLoyer(Joueur j, Terrain terrain)
        {

        }
        public override void Construire(Joueur j, Terrain terrain)
        {

        }
        public override void AcheterTerrain(Joueur j, Terrain terrain)
        {

        }
        public override void StopperSur(Joueur j, Terrain terrain)
        {
            if (j != terrain.proprietaire)
            {
                Console.WriteLine($"Vous êtes tombés sur {terrain.nom} qui appartient à {terrain.proprietaire.nom}");

                int loyer = terrain.CalculerLoyerConstructible();

                if (terrain.maisonsConstruites == 5)
                {
                    Console.WriteLine($"Ce terrain possède un hôtel, vous allez donc devoir payer un loyer de {loyer} M$ à {terrain.proprietaire.nom}");
                }
                else
                {
                    Console.WriteLine($"Ce terrain a {terrain.maisonsConstruites} maisons dessus, vous allez donc devoir payer un loyer de {loyer} M$ à {terrain.proprietaire.nom}");
                }


                //PayerLoyer(luc, montant)
                j.PayerLoyer(terrain.proprietaire, loyer);
            }
            else
            {
                Console.WriteLine($"Vous êtes tombés sur {terrain.nom} qui est votre propriété.");
            }
        }
        public override string ToString()
        {
            return "CONSTRUCTIBLE";
        }
    }

}
