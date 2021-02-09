using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace monopoly.monopoly.cases
{
    public class Gare : Case
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
            Console.WriteLine($"Passage sur : {nom}");
            Thread.Sleep(1000);
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
