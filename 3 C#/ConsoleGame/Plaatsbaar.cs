namespace ConsoleGame
{
    abstract class Plaatsbaar : Tekenbaar
    {
        public Coordinaat Positie;
        public Plaatsbaar(char symbol = ' ')
        {
            this.Symbol = symbol;
        }
        public void ResetPositie()
        {
            Positie = new Coordinaat(0, 0);
        }
        public virtual void Teken()
        {
            Tekener.SchrijfOp(Positie, "" + Symbol);
        }
        public virtual char Symbol { get; }
    }
}