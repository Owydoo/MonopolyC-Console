using System.Collections.Generic;
using System;

namespace monopoly
{
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
    using Lancer = Pair<int, bool>;


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

        public bool JouerTour()
        {
            //Lancer les dés
            Console.WriteLine($"------------------- {nom} joue son tour -------------------");
            Console.WriteLine($"{nom} a {argent}M$ sur son compte.\n");
            Lancer lancer;

            do
            {
                lancer = DiceLauncher.LancerDes();
                //Avancer(lancer.First);
                Avancer(12);
                if (lancer.Second) {
                    Console.WriteLine("Vous avez fait un double, vous rejouez !");
                }

            } while (lancer.Second);

            return VerifDefaite();
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

        /// <summary>
        /// Débite le compte du joueur du prix du loyer et le crédite au proprio
        /// Ne débite que ce qui lui reste s'il n'a pas assez de sous.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="montant"></param>
        public void PayerLoyer(Joueur j, int montant)
        {
            int argentPaye = (argent < montant) ? argent : montant;
            argent -= montant;

            j.CrediteCompte(argentPaye);
            
        }
        
        /// <summary>
        /// Si le joueur a moins que rien d'argent, alors il a perdu.
        /// </summary>
        /// <returns></returns>
        private bool VerifDefaite()
        {
            return (argent < 0);
        }

        /// <summary>
        /// Crédite le joueur de montant
        /// </summary>
        /// <param name="montant"></param>
        private void CrediteCompte(int montant)
        {
            argent += montant;
            Console.WriteLine($"{nom} reçoit {montant} et possède donc {argent}M$");
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