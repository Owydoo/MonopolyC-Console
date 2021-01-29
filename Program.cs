using System;

namespace monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //TODO: Inscription des différents joueurs
            //récup leur noms

            Partie partie = new Partie(3);

            partie.LancerPartie();
        }
    }
}
