namespace ConsoleGame
{
    class Veld : Tekenbaar
    {
        public int Size { get; set; } = 8;
        public void Teken()
        {
            Tekener.SchrijfOp(new Coordinaat(0, 0), "----------");
            for (int i = 1; i < Size; i++)
                Tekener.SchrijfOp(new Coordinaat(0, i), "|        |");
            Tekener.SchrijfOp(new Coordinaat(0, Size), "----------");
        }
    }
}