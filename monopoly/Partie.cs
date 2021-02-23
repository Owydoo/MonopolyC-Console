using System;
using System.Collections.Generic;
using System.Threading;

namespace monopoly
{
    public class Partie
    {
        //private List<Joueur> joueurs;
        public static List<Joueur> joueurs;
        private Plateau plateau;

        public Partie(uint nb_joueurs)
        {
            //TODO: Vérifier que le nombre de joueurs est entre 2 et 6

            joueurs = new List<Joueur>();
            plateau = new Plateau();

            for (int i = 0; i < nb_joueurs; ++i)
            {
                joueurs.Add(new Joueur("Joueur " + (i + 1), 500, this.plateau));
            }

        }

        public Partie()
        {
            plateau = new Plateau();
            joueurs = CreerLesJoueursDeLaPartie(plateau);
        }

        /// <summary>
        /// Interface console permettant de créer un joueur.
        /// </summary>
        /// <returns></returns>
        private static List<Joueur> CreerLesJoueursDeLaPartie(Plateau plateau)
        {
            List<Joueur> resultat = new List<Joueur>();
            bool choixEnCours = true;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Création des joueurs de la partie de Monopoly : ");
            Console.ResetColor();

            do
            {
                resultat.Add(CreerUnJoueur(plateau));

                Console.WriteLine($"Pour le moment, il y a {resultat.Count} joueurs, est-ce suffisant ? [Y/N]");
                string choix = Console.ReadLine().ToLower();
                if (choix == "y")
                {
                    choixEnCours = false;
                }
            } while (choixEnCours);

            return resultat;

            //Si le nombre de joueurs est correct
            //==> return les joueurs
            //Sinon, recommencer

            
        }

        /// <summary>
        /// Méthode demandant au joueurs de créer et d'inscrire les joueurs pour la partie de monopoly.
        /// </summary>
        /// <returns></returns>
        private static Joueur CreerUnJoueur(Plateau plateau)
        {
            bool pasChoisi = true;
            Joueur joueurACreer = new Joueur();

            do
            {
                string nomDuJoueur;
                Console.WriteLine("Indiquez le nom du joueur à inscrire : ");
                nomDuJoueur = Console.ReadLine();

                Console.WriteLine($"Le nom : {nomDuJoueur} vous convient-il ? [Y/N]");
                string choix = Console.ReadLine().ToLower();
                if (choix == "y")
                {
                    joueurACreer = new Joueur(nomDuJoueur, 500, plateau);
                    pasChoisi = false;
                }

            } while (pasChoisi);

            return joueurACreer;

        }

        public void LancerPartie()
        {
            int index = 0;

            while (VerifPartieContinue()) //TODO: vérifie que la partie n'est pas terminée
            {
                bool joueurPerdant = joueurs[index].JouerTour();

                //Retirer un joueur ayant perdu
                if (joueurPerdant)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Le joueur {joueurs[index].nom} est éliminé.");
                    Console.ResetColor();
                    joueurs.Remove(joueurs[index]);
                }

                index++;
                Thread.Sleep(1000);

                if (index >= joueurs.Count)
                {
                    index = 0;
                }
            }

            Joueur gagnant = joueurs[0];


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"La partie est terminée. Bravo à {gagnant} pour sa victoire !");
            Console.ResetColor();
        }


        /// <summary>
        /// Renvoie true si la partie continue.
        /// Renvoie false si la partie se termine, c'est à dire qu'il ne reste plus qu'un joueur.
        /// </summary>
        /// <returns></returns>
        private bool VerifPartieContinue()
        {
            return joueurs.Count > 1;
        }
    }
}