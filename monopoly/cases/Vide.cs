using System;
using System.Collections.Generic;
using System.Text;

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
