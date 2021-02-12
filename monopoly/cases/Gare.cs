using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace monopoly.monopoly.cases
{
    public class Gare : Case
    {
        public uint prix;
        private Joueur proprietaire;
        public bool possede; //true si la case a un propriétaire


        public Gare(string _nom, Plateau _plateau)
        {
            this.nom = _nom;
            prix = 200;
            proprietaire = null;
            possede = false;

            this.plateau = _plateau;
        }
        public override void PasserSur(Joueur j)
        {
            Console.WriteLine($"Passage sur : {nom}");
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Ce qu'il se passe quand un joueur s'arrête sur une gare.
        /// </summary>
        /// <param name="j"></param>
        public override void StopperSur(Joueur j)
        {
            if (possede && (j != proprietaire))
            {
                //Calculer take de passage
                int taxe = CalculerTaxeDePassage();

                //Nombre de gares possédées par(propriétaire de la gare)
                //==> nbGaresPossédées
                //==> taxe

                //PayerLoyer(proprio, taxe)
                    //débuteCompte(taxe)
                //Pas besoin de vérifier que le joueur a assez d'argent, car c'est la fonction
                //VerifDefaite dans JouerTour() qui s'en occupe.
                j.PayerLoyer(proprietaire, taxe);

                Console.WriteLine($"{j.nom} a payé {taxe} M$ et possède donc {j.argent} M$");


            }
            else if(j == proprietaire)
            {
                Console.WriteLine("Vous êtes le propriétaire de cette gare.");
            }
            else if (!possede) //Le joueur peut alors acheter la case.
            {
                Console.WriteLine($"La {nom} est disponible, voulez vous l'acheter ? [Y/N]");
                string choice = Console.ReadLine().ToLower();

                if (choice == "y")
                {
                    AcheterGare(j);
                }
                else
                {
                    Console.WriteLine("Vous avez décidé de ne pas acheter cette case");
                }
            }


        }

        /// <summary>
        /// Fait l'achat de la gare par le joueur.
        /// </summary>
        /// <param name="j"></param>
        private void AcheterGare(Joueur j)
        {
            bool achatpossible = j.VerifAchatPossible(prix);
            if (achatpossible)
            {
                this.EnregistrerAcheteur(j);
                j.DebiteCompte(prix);
                Console.WriteLine($"Il vous reste {j.argent} M$ sur votre compte.");
            }
            else
            {
                Console.WriteLine("Vous n'avez pas assez d'argent pour acheter cette propriété.");
            }
        }

        /// <summary>
        /// Enregistrer l'acheteur dans les variables de la Case
        /// </summary>
        /// <param name="j"></param>
        private void EnregistrerAcheteur(Joueur j)
        {
            proprietaire = j;
            possede = true;
        }

        /// <summary>
        /// calcule la taxe de passage en fonction du nombre de gares possédées par le propriétaire.
        /// </summary>
        private int CalculerTaxeDePassage()
        {
            int taxe = 0;
            int nbGaresPossedees = plateau.NombreGaresPourJoueur(proprietaire);
            switch (nbGaresPossedees)
            {
                case 0:
                    taxe = 0;
                    break;
                case 1:
                    taxe = 25;
                    break;
                case 2:
                    taxe = 50;
                    break;
                case 3:
                    taxe = 100;
                    break;
                case 4:
                    taxe = 200;
                    break;
                default:
                    break;
            }

            return taxe;

        }

        public bool PossedeePar(Joueur j)
        {
            return proprietaire == j;
        }


    }
}
