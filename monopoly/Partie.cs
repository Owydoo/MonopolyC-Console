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