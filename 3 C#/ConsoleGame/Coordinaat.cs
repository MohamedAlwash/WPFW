namespace ConsoleGame
{
    struct Coordinaat
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Coordinaat(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public static Coordinaat operator +(Coordinaat c1, Coordinaat c2)
        {
            return new Coordinaat(c1.X + c2.X, c1.Y + c2.Y);
        }
    }
}