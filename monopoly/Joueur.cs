using System.Collections.Generic;
using System;
using System.Threading;

namespace monopoly
{
    //class Lancer : Pair<int, bool>
    //{
    //    private uint resultat;
    //    private bool estUnDouble;

    //    public Lancer()
    //    {
    //        resultat = super.First;
    //        estUnDouble = Pa;
    //    }
    //}
    using Lancer = Pair<int, bool>;


    public class Joueur
    {
        public int argent;
        public string nom;
        private Plateau plateau;
        private Case position;

        public Joueur(string nom, int argent_initial, Plateau plateau)
        {
            this.argent = argent_initial;
            this.nom = nom;
            this.plateau = plateau;

            position = plateau.GetDepart();
        }

        public Joueur()
        {

        }

        public bool JouerTour()
        {
            //Lancer les d�s
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"------------------- {nom} joue son tour -------------------");
            Thread.Sleep(10);
            Console.ResetColor();
            Console.WriteLine($"{nom} a {argent}M$ sur son compte et est sur la case {position.nom}.\n");
            Lancer lancer;

            do
            {
                lancer = DiceLauncher.LancerDes();

                //Avancer(lancer.First); //truc avant test

                //==================== TEST
                //Choisir de combien faire avancer le d�
                Console.WriteLine("Choisir la valeur du dé :");
                int nbDice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Est-ce un double ? [Y/N]");
                string choice = Console.ReadLine().ToLower();

                //lancer.Second = choice == "y" ? true , false;
                if (choice == "y")
                {
                    lancer.Second = true;
                }
                else
                {
                    lancer.Second = false; 
                }
                Avancer(nbDice);

                //==================== fin test


                if (lancer.Second) {
                    Console.WriteLine("Vous avez fait un double, vous rejouez !");
                }

            } while (lancer.Second);

            Terrain terrainChoisi;
            do
            {
                //terrainChoisi = plateau.AfficheCasesConstructiblesEtChoixTerrain(this);
                terrainChoisi = AfficheCasesConstructiblesEtChoixTerrain();
                if (terrainChoisi != null)
                {
                    int nbMaisonsAConstruire = ChoisirNbMaisons(terrainChoisi);
                    if (!(nbMaisonsAConstruire <= 0))
                    {
                        terrainChoisi.Construire(nbMaisonsAConstruire);
                    }
                }

            } while (terrainChoisi != null);
            //Affiches Cases constructibles s'il y en a

            return VerifDefaite();
        }

        /// <summary>
        /// Retire du compte du joueur l'argent pass� en argument
        /// </summary>
        /// <param name="_argentADebiter"></param>
        internal void DebiteCompte(uint _argentADebiter)
        {
            argent = argent - (int)_argentADebiter;
        }

        /// <summary>
        /// V�rifie si le joueur a plus ou moins d'argent que prix
        /// true si le joueur a suffisamment d'argent.
        /// </summary>
        /// <param name="prixDepart"></param>
        /// <returns></returns>
        internal bool VerifAchatPossible(uint _prix)
        {
            return argent >= _prix;
        }

        /// <summary>
        /// Débite le compte du joueur du prix du loyer et le crédite au proprio
        /// Ne débite que ce qui lui reste s'il n'a pas assez de sous.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="montant"></param>
        public void PayerLoyer(Joueur j, int montant)
        {
            int argentPaye = (argent < montant) ? argent : montant;
            argent -= montant;

            j.CrediteCompte(argentPaye);

            
        }
        
        /// <summary>
        /// Si le joueur a moins que rien d'argent, alors il a perdu.
        /// </summary>
        /// <returns></returns>
        public bool VerifDefaite()
        {
            return (argent < 0);
        }

        /// <summary>
        /// Cr�dite le joueur de montant
        /// </summary>
        /// <param name="montant"></param>
        private void CrediteCompte(int montant)
        {
            argent += montant;
            Console.WriteLine($"{nom} reçoit {montant} et possède donc {argent}M$");
        }

        private void Avancer(int n)
        {
            Case current = position;
            for (int i = 0; i < n; ++i)
            {
                current = current.GetCaseSuivante();
                current.PasserSur(this);
            }
            position = current;
            position.StopperSur(this);

        }

        /// <summary>
        /// Demande au joueur combien de maisons veut-il construire sur terrainChoisi et
        /// renvoie le r�sultat.
        /// </summary>
        /// <param name="terrainChoisi"></param>
        /// <returns></returns>
        private int ChoisirNbMaisons(Terrain terrainChoisi)
        {
            Console.WriteLine($"Combien de maisons voulez-vous construire sur {terrainChoisi.nom} ?");
            int nbMaisons = Convert.ToInt32(Console.ReadLine());
            return nbMaisons;
        }

        /// <summary>
        /// Affiche au joueur les cases et les couleurs des cases sur lesquelles il peut construire.
        /// Renvoie le terrain qu'il a choisi.
        /// </summary>
        internal Terrain AfficheCasesConstructiblesEtChoixTerrain()
        {
            List<Couleur> _couleursConstructibles = plateau.GetCouleursConstructible(this);
            if (_couleursConstructibles.Count == 0) //Aucun terrain disponible à la construction
            {
                Console.WriteLine("Vous ne pouvez pas construire de maisons pour le moment.");
                return null;
            }
            else
            {
                int indiceTerrain = 0; //Un indice sur chaque terrain qui permettra au joueur de choisir où construire

                List<Terrain> _terrainsConstructibles = plateau.GetTerrainsConstructible(this, _couleursConstructibles);
                foreach (var _couleur in _couleursConstructibles)
                {
                    Console.WriteLine($"Dans le groupe {_couleur} : ");
                    foreach (var _terrain in _terrainsConstructibles)
                    {
                        indiceTerrain++;
                        Console.WriteLine($"{indiceTerrain} : {_terrain.nom} qui a déjà {_terrain.maisonsConstruites} maisons. ({_terrain.prixMaison} M$ par maison achetée)");
                    }
                    Console.WriteLine("---");
                }

                Console.WriteLine("Indiquez le numéro du terrain sur lequel vous voulez construire, et 0 si vous ne voulez pas construire.");
                //TODO : gestion d'erreur si le choix donné n'est pas un entier.
                int choixTerrain = Convert.ToInt32(Console.ReadLine().ToLower());
                if (!(choixTerrain <= 0 || choixTerrain > _terrainsConstructibles.Count))
                {
                    return _terrainsConstructibles[choixTerrain - 1];
                }
                else if (choixTerrain == 0)
                {
                    return null;
                }

                else
                {
                    Console.WriteLine("Veuillez indiquer un nombre correspondant aux indices donnés plus haut.");
                    return null;
                }
            }
        }
    }
}