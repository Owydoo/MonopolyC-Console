using System;
using System.Threading;

namespace monopoly
{
    public class Depart : Case
    {
        public Depart() {
            nom = "Depart";
        }

        public override void PasserSur(Joueur j)
        {
            //TODO: +200 !!!
            Console.WriteLine($"Passage sur : {nom}");
            Thread.Sleep(1000);
        }

        public override void StopperSur(Joueur j)
        {
            throw new System.NotImplementedException();
        }
    }
}