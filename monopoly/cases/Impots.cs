using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace monopoly.monopoly.cases
{
    public class Impots : Case
    {
        private uint frais;


        public Impots(string _nom, uint _frais)
        {
            this.nom = _nom;
            this.frais = _frais;
        }
        public override void PasserSur(Joueur j)
        {
            Console.WriteLine($"Passage sur : {nom}");
            Thread.Sleep(1000);
        }

        public override void StopperSur(Joueur j)
        {
            Console.WriteLine($"Vous êtes arrivé sur la case {nom} et versez donc {frais} M$ à la banque.");
            j.DebiteCompte(frais);
            Console.WriteLine($"Il vous reste donc {j.argent} M$ dans votre compte.");
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
