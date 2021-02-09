namespace monopoly
{
    public abstract class Case
    {
        protected string nom;
        private Case suivante;

        //TODO: reférence plateau
        public Plateau plateau;

        public abstract void PasserSur(Joueur j);
        public abstract void StopperSur(Joueur j);

        public void SetCaseSuivante(Case c)
        {
            this.suivante = c;
        }

        public Case GetCaseSuivante(){
            return suivante;
        }

        public override string ToString()
        {
            return $"Case : {nom}\n";
        }

    }


}