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
                }
                j.DebiteCompte(terrain.prixDepart);
                Console.WriteLine($"Il vous reste {j.argent} sur votre compte.");

            } else {
                Console.WriteLine("Lol le nullos !! C'est pas tres startup nation ca...");
            }
        }
        public override string ToString()
        {
            return "ACHETABLE : PAY WITH STONKS";
        }

    }
}
