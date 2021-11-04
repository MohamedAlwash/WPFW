namespace ConsoleGame
{
    class Speler : Plaatsbaar
    {
        public string Naam { get; set; }
        public string Achternaam { get; set; }
        public string Volledigenaam
        {
            get
            {
                return Naam + " " + Achternaam;
            }
        }
        public int Punten { get; set; }
        public Speler() : base('*') { }
        public static bool operator >(Speler sp1, Speler sp2)
        {
            return sp1.Punten > sp2.Punten;
        }
        public static bool operator <(Speler sp1, Speler sp2)
        {
            return sp1.Punten < sp2.Punten;
        }
    }
}