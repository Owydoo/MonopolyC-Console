using System.Collections.Generic;
using System;

namespace monopoly
{
    using Lancer = Pair<int, bool>;
    //class Lancer : Pair<int, bool>
    //{
    //    private uint resultat;
    //    private bool estUnDouble;

    //    public Lancer()
    //    {
    //        resultat = super.First;
    //        estUnDouble = Pa;
    //    }
    //}


    class Joueur
    {
        private int argent;
        private string nom;
        private Plateau plateau;
        private Case position;

        public Joueur(string nom, int argent_initial, Plateau plateau)
        {
            this.argent = argent_initial;
            this.nom = nom;
            this.plateau = plateau;

            position = plateau.GetDepart();
        }
        private Lancer LancerDes()
        {
            Random r = new Random();
            int dice1 = r.Next(1, 7);
            int dice2 = r.Next(1, 7);
            return new Lancer(dice1 + dice2, dice1 == dice2);
        }

        public void JouerTour()
        {
            //Lancer les dés
            Console.WriteLine($"{nom} joue son tour\n");
            Lancer lancer;

            do
            {
                lancer = LancerDes();
                Avancer(lancer.First);

            } while (lancer.Second);
        }

        private void Avancer(int n)
        {
            Case current = position;
            for (int i = 0; i < n; ++i)
            {
                current = current.GetCaseSuivante();
                current.PasserSur(this);
            }
            position = current;
            position.StopperSur(this);
        }
    }
}