namespace monopoly
{
    class Terrain : Case
    {
        private uint prixDepart;
        private uint loyer;
        private Couleur couleur;
        private Joueur proprietaire;

        public Terrain(string nom, uint prixDepart, uint loyer, Couleur couleur)
        {
            this.nom = nom;
            this.prixDepart = prixDepart;
            this.loyer = loyer;
            this.couleur = couleur;
        }

        public override void PasserSur(Joueur j)
        {
            throw new System.NotImplementedException();
        }
        public override void StopperSur(Joueur j)
        {
            throw new System.NotImplementedException();
        }

        public Couleur GetCouleur()
        {
            return couleur;
        }

        public bool PossedeePar(Joueur j)
        {
            return proprietaire == j;
        }
    }
}