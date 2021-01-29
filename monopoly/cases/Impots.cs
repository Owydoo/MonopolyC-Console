using System;
using System.Collections.Generic;
using System.Text;

namespace monopoly.monopoly.cases
{
    class Impots : Case
    {
        private uint frais;


        public Impots(string _nom, uint _frais)
        {
            this.nom = _nom;
            this.frais = _frais;
        }
        public override void PasserSur(Joueur j)
        {
            throw new NotImplementedException();
        }

        public override void StopperSur(Joueur j)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
