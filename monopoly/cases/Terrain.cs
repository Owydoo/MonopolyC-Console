using System;
using System.Threading;

namespace monopoly
{
    public class Terrain : Case
    {
        public uint prixDepart;
        private uint loyer;
        public uint prixMaison;
        private Couleur couleur;
        public Joueur proprietaire;
        public uint maisonsConstruites;

        public uint[] loyerMaisons;

        public EtatTerrain etat;

        public Terrain(string _nom, uint _prixDepart, uint _loyer, Couleur _couleur, Plateau _plateau, 
            uint _prixMaison, uint[] _loyerMaisons)
        {
            this.nom = _nom;
            this.prixDepart = _prixDepart;
            this.loyer = _loyer;
            this.couleur = _couleur;
            this.etat = new EtatAchetable();
            //=========================== TEST
            //this.etat = new EtatConstructible();

            //this.proprietaire = new Joueur();
            //=============================
            maisonsConstruites = 0;
            this.plateau = _plateau;
            this.prixMaison = _prixMaison;

            this.loyerMaisons = _loyerMaisons;
        }



        public override void PasserSur(Joueur j)
        {
            Console.WriteLine($"Passage sur : {nom}");
            Thread.Sleep(1000);
        }
        public override void StopperSur(Joueur j)
        {
            Console.WriteLine($"Arret sur : {nom}");
            etat.StopperSur(j, this);
        }
        public void Construire(Joueur j)
        {
            etat.Construire(j, this);
        }

        public void AcheterTerrain(Joueur j)
        {
            etat.AcheterTerrain(j, this);
        }

        public void PayerLoyer(Joueur j)
        {
            etat.PayerLoyer(j, this);
        }

        public Couleur GetCouleur()
        {
            return couleur;
        }

        public bool PossedeePar(Joueur j)
        {
            return proprietaire == j;
        }

        public int CalculerLoyer()
        {
            int nb = (int)loyer;

            //loyer doublé si le joueur possède tous les terrains de la couleur
            if(plateau.VerifAutreTerrainPossedeGroupe(couleur, proprietaire, this)) {
                nb *= 2;
            }
            return nb;
        }

        /// <summary>
        /// Donne le loyer d'un terrain constructible en fonction du nombre de maisons dessus.
        /// </summary>
        /// <returns></returns>
        internal int CalculerLoyerConstructible()
        {
            int _loyer = (int)loyer;

            switch (maisonsConstruites)
            {
                case 0:
                    _loyer *= 2;
                    break;
                case 1:
                    _loyer = (int)loyerMaisons[0];
                    break;
                case 2:
                    _loyer = (int)loyerMaisons[1];
                    break;
                case 3:
                    _loyer = (int)loyerMaisons[2];
                    break;
                case 4:
                    _loyer = (int)loyerMaisons[3];
                    break;
                case 5:
                    _loyer = (int)loyerMaisons[4];
                    break;
                default:
                    break;
            }
            return _loyer;
        }

        /// <summary>
        /// Enregistre d'abord le joueur en tant que propriétaire.
        /// Si l'acheteur possède les autres terrains du groupe, alors
        /// l'état du terrain passe à constructible.
        /// </summary>
        /// <param name="j"></param>
        public void EnregistreAcheteur(Joueur j)
        {
            proprietaire = j;

            //Console.WriteLine(plateau.VerifAutreTerrainPossedeGroupe(couleur, j, this));
            this.etat = new EtatAchete();
            
            plateau.SwitchConstructible(couleur);

        }

        public override string ToString()
        {
            string _propri = "";
            if (proprietaire == null)
            {
                _propri = "pas de propriétaire";
            }
            else
            {
                _propri = proprietaire.nom;
            }

            string result = $"nom : {nom}\n" +
                $"prix d'achat : {prixDepart}\n"+
                $"loyer de départ : {loyer}\n" +
                $"couleur : {couleur}\n" +
                $"propriétaire : {_propri}\n" +
                $"état du terrain : {etat.ToString()}\n" +
                $"nombres de maisons construites : {maisonsConstruites}";
            return result;
        }

        /// <summary>
        /// Enregistrer les maisons à construire sur this.
        /// </summary>
        /// <param name="nbMaisonsAConstruire"></param>
        internal void EnregistrerMaisons(int nbMaisonsAConstruire)
        {
            uint prixAPayer = (uint)nbMaisonsAConstruire * prixMaison;

            if (this.VerifNbMaisons(nbMaisonsAConstruire))
            {
                if(proprietaire.VerifAchatPossible(prixAPayer))
                {
                    proprietaire.DebiteCompte(prixAPayer);
                    maisonsConstruites += (uint)nbMaisonsAConstruire;
                    Console.WriteLine($"Vous avez dorénavant {maisonsConstruites} maisons sur le terrain '{nom}'");
                }
                else
                {
                    Console.WriteLine("Vous n'avez pas assez d'argent pour acheter autant de maison.");
                }
            }
            else
            {
                Console.WriteLine($"Cela ferait trop de maisons pour le terrain {nom}");
            }
            
            
        }



        /// <summary>
        /// Vérifie que le nombre de maisons est inférieur à 5 même en y ajoutant
        /// le nombre de maisons que le joueur veut construire.
        /// return true si le nombre convient
        /// </summary>
        /// <param name="nbMaisonsAConstruire"></param>
        /// <returns></returns>
        private bool VerifNbMaisons(int nbMaisonsAConstruire)
        {
            return ((nbMaisonsAConstruire + maisonsConstruites >= 0) && (nbMaisonsAConstruire + maisonsConstruites <= 5));
        }
    }
}