using System;
using System.Collections.Generic;

namespace monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Bienvenue dans le Monopoly !");
            Console.ResetColor();

            var arr = new[]
            {
                @"░░░░░░░░░░░░░░░░░░░░░░░░░▄░░░░░░░░░░░░░",
                @"░░░░░░░░░░░░░░▄▄▀▀██░░░░████░░░░░░░░░░░",
                @"░░░░░░░░░░░░▄██▄░▄███░░▄██▄░░░░░░░░░░░░",
                @"░░░░░░░░░░░░█████▄▄▄███▀░▀██▄░░░░░░░░░░",
                @"░░░░░▄██░░░░░████▀▀░░░▄█░░░▀███▄░░░░░░░",
                @"░▄▄█▀▀▀░█▄▄▄░███░░░▀░▄▄▄█▄░░█▄█▄█░░░░░░",
                @"░███▀▀▀████████▄▄░▄▄▀░▄▄█▀░▄██████▄░░░░",
                @"░░░░░░░░░▀▀██████▄░▀▀█▄█▄▄▄████▀░▀██▄░░",
                @"░░░░░░░░░░░░▀█████▄███████████▀░░░░░▀█▄",
                @"░░░░░░░░░░░░░██████░░░████▀▀░░░░░░░░░░░",
                @"░░░░░░░▀▄░░▄▄█████▀█░░███░░░░░░░░░░░░░░",
                @"░░░░░░░░▀████████▀░░█████▄▄░░░░░░░░░░░░",
                @"░░░░░░░░░░▀▀█████░░██████▀░░░░░░░░░░░░░",
                @"░░░░░░░░░░░░█████░▄██████▄░░░░░░░░░░░░░",
                @"░░░░░░░░░░░░░░▀░░▀▀██████▀░░░░░░░░░░░░░",
                @"░░░░░░░░░░░░░░░░▄██████▀▀░░░░░░░░░░░░░░",
                @"░░░░░░░░░░░░░░░░█████▀░░░░░░░░░░░░░░░░░",
                @"░░░░░░░░░░░░░░░░██▀▀░░░░░░░░░░░░░░░░░░░",
                @"░░░░░░░░░░░░░░░░██░░░░░░░░░░░░░░░░░░░░░",
            };

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            foreach (string line in arr)
            {
                Console.WriteLine(line);
            }
            Console.ResetColor();
            //TODO: Inscription des différents joueurs
            //récup leur noms

            //List<Joueur> joueursInscrits = CreerLesJoueursDeLaPartie();


            //Partie partie = new Partie(3);
            Partie partie = new Partie();

            partie.LancerPartie();
        }

        /// <summary>
        /// Méthode demandant au joueurs de créer et d'inscrire les joueurs pour la partie de monopoly.
        /// </summary>
        /// <returns></returns>
        //private static List<Joueur> CreerLesJoueursDeLaPartie()
        //{
        //    List<Joueur> resultat = new List<Joueur>();
        //    bool choixEnCours = true;

        //    do
        //    {
        //        resultat.Add(CreerUnJoueur());
        //    } while (choixEnCours);

        //    //Si le nombre de joueurs est correct
        //        //==> return les joueurs
        //    //Sinon, recommencer
        //}

        /// <summary>
        /// Interface console permettant de créer un joueur.
        /// </summary>
        /// <returns></returns>
        //private static Joueur CreerUnJoueur()
        //{
        //    bool pasChoisi = true;

        //    do
        //    {
        //        string nomDuJoueur;
        //        Console.WriteLine("Indiquez le nom du joueur à inscrire : ");
        //        nomDuJoueur = Console.ReadLine();

        //        Console.WriteLine($"Le nom : {nomDuJoueur} vous convient-il ? [Y/N]");
        //        string choix = Console.ReadLine().ToLower();
        //        if (choix == "y")
        //        {
        //            pasChoisi = false;
        //            Joueur jouerACreer = new Joueur()
        //        }

        //    } while (pasChoisi);



        //}
    }
}
