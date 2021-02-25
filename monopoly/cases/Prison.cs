using System;
using System.Threading;

namespace monopoly
{
    public class Prison : Case
    {
        Prison() {
            nom = "Prison";
        }

        public override void PasserSur(Joueur j)
        {
            Console.WriteLine($"Passage sur : {nom}");
            Thread.Sleep(1000);
        }

        public override void StopperSur(Joueur j)
        {

        }
    }
}