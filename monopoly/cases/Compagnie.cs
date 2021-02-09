using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace monopoly.monopoly.cases
{
    class Compagnie : Case
    {
        private uint prix;

        public Compagnie(string _nom)
        {
            this.nom = _nom;
            prix = 150;
        }

        public override void PasserSur(Joueur j)
        {
            Console.WriteLine($"Passage sur : {nom}");
            Thread.Sleep(1000);
        }

        public override void StopperSur(Joueur j)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Case : {nom}";
        }
    }
}
