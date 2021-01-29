using System;
using System.Collections.Generic;
using System.Text;

namespace monopoly.monopoly.cases
{
    class Gare : Case
    {
        public uint prix;
        private Joueur proprietaire;

        public Gare(string _nom)
        {
            this.nom = _nom;
            prix = 200;
            proprietaire = null;
        }
        public override void PasserSur(Joueur j)
        {
            throw new System.NotImplementedException();
        }
        public override void StopperSur(Joueur j)
        {
            throw new System.NotImplementedException();
        }
        public bool PossedeePar(Joueur j)
        {
            return proprietaire == j;
        }
    }
}
