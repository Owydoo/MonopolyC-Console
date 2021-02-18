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
            //TODO: V�rifier que le nombre de joueurs est entre 2 et 6

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
        /// Interface console permettant de cr�er un joueur.
        /// </summary>
        /// <returns></returns>
        private static List<Joueur> CreerLesJoueursDeLaPartie(Plateau plateau)
        {
            List<Joueur> resultat = new List<Joueur>();
            bool choixEnCours = true;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cr�ation des joueurs de la partie de Monopoly : ");
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
        /// M�thode demandant au joueurs de cr�er et d'inscrire les joueurs pour la partie de monopoly.
        /// </summary>
        /// <returns></returns>
        private static Joueur CreerUnJoueur(Plateau plateau)
        {
            bool pasChoisi = true;
            Joueur joueurACreer = new Joueur();

            do
            {
                string nomDuJoueur;
                Console.WriteLine("Indiquez le nom du joueur � inscrire : ");
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

            while (true) //TODO: v�rifie que la partie n'est pas termin�e
            {
                joueurs[index].JouerTour();
                index++;
                Thread.Sleep(1000);

                if (index >= joueurs.Count)
                {
                    index = 0;
                }
            }
            
        }



    }
}