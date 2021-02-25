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
            j.argent += 200;

            Console.WriteLine($"Vous passez par la case départ, vous gagnez 200 M$");
            Thread.Sleep(1000);
        }

        public override void StopperSur(Joueur j)
        {
            
        }
    }
}