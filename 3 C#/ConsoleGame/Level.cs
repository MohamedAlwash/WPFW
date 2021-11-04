using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    class Level : Tekenbaar
    {
        private Veld veld = new Veld();
        public List<Vijandje> Vijandjes { get; set; }
        public List<Muntje> Muntjes { get; set; }
        public string Naam { get; set; }
        public int? Moeilijkheid { get; set; }
        public void Teken()
        {
            veld.Teken();
            foreach (var vijandje in Vijandjes)
            {
                vijandje.Teken();
            }
            foreach (var muntje in Muntjes)//gebruik tenminste 1 keer het keyword var
            {
                muntje.Teken();
            }
            Tekener.SchrijfOp(new Coordinaat(0, veld.Size + 1), Naam ?? "Naamloos level");
            Console.Write(Vijandjes?.Count.AantalString() ?? "0");
            Console.WriteLine(" Vijandjes");
            if (Moeilijkheid != null)
                Console.WriteLine("Moeilijkheidsgraad: " + Moeilijkheid.Value.AantalString());
        }
    }
}