using System;
using System.Threading;

namespace monopoly
{
    public class Terrain : Case
    {
        public uint prixDepart;
        private uint loyer;
        private Couleur couleur;
        public Joueur proprietaire;

        private EtatTerrain etat;

        public Terrain(string nom, uint prixDepart, uint loyer, Couleur couleur, Plateau plateau)
        {
            this.nom = nom;
            this.prixDepart = prixDepart;
            this.loyer = loyer;
            this.couleur = couleur;
            this.etat = new EtatAchetable();


            this.plateau = plateau;
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

        /// <summary>
        /// Enregistre d'abord le joueur en tant que propriétaire.
        /// Si l'acheteur possède les autres terrains du groupe, alors
        /// l'état du terrain passe à constructible.
        /// </summary>
        /// <param name="j"></param>
        internal void EnregistreAcheteur(Joueur j)
        {
            proprietaire = j;

            Console.WriteLine(plateau.VerifAutreTerrainPossedeGroupe(couleur, j, this));
            if(plateau.VerifAutreTerrainPossedeGroupe(couleur, j, this))
            {
                //etat du terrain = constructible
            }

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
                $"état du terrain : {etat.ToString()}\n";
            return result;
        }
    }
}