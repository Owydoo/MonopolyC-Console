using System;
using System.Collections.Generic;
using System.Threading;

namespace monopoly
{
    public class Partie
    {
        private List<Joueur> joueurs;
        private Plateau plateau;

        public Partie(uint nb_joueurs)
        {
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

            while (true) //vérifie que la partie n'est pas terminée
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