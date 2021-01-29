namespace monopoly
{
    class Prison : Case
    {
        Prison() {
            nom = "Prison";
        }

        public override void PasserSur(Joueur j)
        {
            throw new System.NotImplementedException();
        }

        public override void StopperSur(Joueur j)
        {
            throw new System.NotImplementedException();
        }
    }
}