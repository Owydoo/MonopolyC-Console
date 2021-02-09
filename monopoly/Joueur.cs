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


    public class Joueur
    {
        public int argent;
        public string nom;
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
            Console.WriteLine($"{nom} joue son tour.");
            Console.WriteLine($"{nom} a {argent}M$ sur son compte.\n");
            Lancer lancer;

            do
            {
                lancer = LancerDes();
                //Avancer(lancer.First);
                //TODO: CHANGERRRR
                Avancer(3);

            } while (lancer.Second);
        }

        /// <summary>
        /// Retire du compte du joueur l'argent passé en argument
        /// </summary>
        /// <param name="_argentADebiter"></param>
        internal void DebiteCompte(uint _argentADebiter)
        {
            argent = argent - (int)_argentADebiter;
        }

        /// <summary>
        /// Vérifie si le joueur a plus ou moins d'argent que prix
        /// true si le joueur a suffisamment d'argent.
        /// </summary>
        /// <param name="prixDepart"></param>
        /// <returns></returns>
        internal bool VerifAchatPossible(uint _prix)
        {
            return argent >= _prix;
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