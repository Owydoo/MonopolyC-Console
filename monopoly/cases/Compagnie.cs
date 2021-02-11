using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace monopoly
{
    using Lancer = Pair<int, bool>;

    class Compagnie : Case
    {
        private uint prix;
        public Joueur proprietaire;
        public bool possede;

        public Compagnie(string _nom, Plateau _plateau)
        {
            this.nom = _nom;
            prix = 150;
            proprietaire = null;
            possede = false;

            this.plateau = _plateau;
        }

        public override void PasserSur(Joueur j)
        {
            Console.WriteLine($"Passage sur : {nom}");
            Thread.Sleep(1000);
        }


        public override void StopperSur(Joueur j)
        {
            //Si cette case est possédée.
            if(possede == true)
            {
                if (j != this.proprietaire)
                {
                    int frais = this.CalculerFrais();

                    j.PayerLoyer(this.proprietaire, frais);

                }
                else
                {
                    Console.WriteLine("Vous êtes propriétaire de cette compagnie.");
                }
            } else {
                //Le joueur peut acheter la case.

                Console.WriteLine($"La {nom} est disponible, voulez vous l'acheter ? [Y/N]");
                string choice = Console.ReadLine().ToLower();
                if (choice == "y")
                {
                    bool achatPossible = j.VerifAchatPossible(prix);
                    if (achatPossible)
                    {
                        this.EnregistrerAcheteur(j);
                        j.DebiteCompte(prix);
                        Console.WriteLine($"Il vous reste {j.argent} sur votre compte.");
                    }
                    else
                    {
                        Console.WriteLine("Vous n'avez pas assez d'argent pour acheter cette propriété.");
                    }
                }
                else
                {
                    Console.WriteLine("Vous avez décidé de ne pas acheter cette case.");
                }
            }

        }

        private void EnregistrerAcheteur(Joueur j)
        {
            proprietaire = j;
            possede = true;
        }

        private int CalculerFrais()
        {
            Lancer l = DiceLauncher.LancerDes();

            int frais = l.First * 4;

            if (plateau.VerifCompagniesPossedeesPar(this.proprietaire))
            {
                frais = l.First * 10;
            }
            return frais;
        }

        public override string ToString()
        {
            return $"Case : {nom}";
        }
    }
}
