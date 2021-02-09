using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace monopoly.monopoly.cases
{
    class Vide : Case
    {

        public Vide(string _nom)
        {
            this.nom = _nom;
        }
        public override void PasserSur(Joueur j)
        {
            Console.WriteLine($"Passage sur : {nom}");
            Thread.Sleep(1000);
        }

        public override void StopperSur(Joueur j)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
