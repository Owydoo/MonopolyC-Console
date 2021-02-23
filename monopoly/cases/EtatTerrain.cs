using System;
using System.Collections.Generic;
using System.Text;

namespace monopoly
{
    public abstract class EtatTerrain
    {
        public abstract void PayerLoyer(Joueur j, Terrain terrain);
        public abstract void Construire(Joueur j, Terrain terrain, int nbMaisonsAConstruire);
        public abstract void AcheterTerrain(Joueur j, Terrain terrain);
        public abstract void StopperSur(Joueur j, Terrain terrain);
    }

    public class EtatAchetable : EtatTerrain
    {
        public EtatAchetable() { }
        public override void PayerLoyer(Joueur j, Terrain terrain)
        {

        }
        public override void Construire(Joueur j, Terrain terrain, int nbMaisonsAConstruire)
        {

        }
        public override void AcheterTerrain(Joueur j, Terrain terrain)
        {
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
        public override void StopperSur(Joueur j, Terrain terrain)
        {
            Console.WriteLine(terrain.ToString());
            Console.WriteLine("Voulez-vous acheter ce terrain ?[Y/N]");
            string choice = Console.ReadLine().ToLower();
            if (choice == "y")
            {
                AcheterTerrain(j, terrain);
            }
            else
            {
                Console.WriteLine("Vous n'avez pas voulu acheter ce terrain.");
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
            Console.WriteLine($"Vous êtes tombés sur {terrain.nom} qui appartient à {terrain.proprietaire.nom}");
            int loyer = terrain.CalculerLoyer();
            j.PayerLoyer(terrain.proprietaire, loyer);
        }
        public override void Construire(Joueur j, Terrain terrain, int nbMaisonsAConstruire)
        {

        }
        public override void AcheterTerrain(Joueur j, Terrain terrain)
        {

        }
        public override void StopperSur(Joueur j, Terrain terrain)
        {
            if (j != terrain.proprietaire)
            {
                PayerLoyer(j, terrain);
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
            j.PayerLoyer(terrain.proprietaire, loyer);
        }
        public override void Construire(Joueur j, Terrain terrain, int nbMaisonsAConstruire)
        {
            uint prixAPayer = (uint)nbMaisonsAConstruire * terrain.prixMaison;

            if (terrain.VerifNbMaisons(nbMaisonsAConstruire))
            {
                if(j.VerifAchatPossible(prixAPayer))
                {
                    j.DebiteCompte(prixAPayer);
                    terrain.maisonsConstruites += (uint)nbMaisonsAConstruire;
                    Console.WriteLine($"Vous avez dor�navant {terrain.maisonsConstruites} maisons sur le terrain '{terrain.nom}'");
                }
                else
                {
                    Console.WriteLine("Vous n'avez pas assez d'argent pour acheter autant de maison.");
                }
            }
            else
            {
                Console.WriteLine($"Cela ferait trop de maisons pour le terrain {terrain.nom}");
            }
        }
        public override void AcheterTerrain(Joueur j, Terrain terrain)
        {

        }
        public override void StopperSur(Joueur j, Terrain terrain)
        {
            if (j != terrain.proprietaire)
            {
                PayerLoyer(j, terrain);
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
