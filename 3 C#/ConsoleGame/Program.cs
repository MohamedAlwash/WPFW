using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    interface Tekenbaar
    {
        void Teken();
    }
    class NegatiefTekenenException : Exception { }
    static class Tekener
    {
        public static void SchrijfOp(Coordinaat Positie, string Text)
        {
            if (Positie.X < 0 || Positie.Y < 0)
                throw new NegatiefTekenenException();
            Console.SetCursorPosition(Positie.X, Positie.Y);
            Console.WriteLine(Text);
        }
    }
    static class AantalExtensie
    {
        public static String AantalString(this int num)
        {
            if (num >= 1000000000) { return (num / 1000000000).ToString() + "B"; }
            if (num >= 1000000) { return (num / 1000000).ToString() + "M"; }
            if (num >= 1000) { return (num / 1000).ToString() + "k"; }
            return num.ToString();
        }
    }
    public class score
    {
        public String Speler { get; set; }
        public int Index { get; set; }

        public score(int index) {
            Index = index;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Speler s = null;
            Console.CursorVisible = false;
            try
            {
                menu.start();
                s = new Speler() { Punten = 10 };
                s.Naam = Console.ReadLine();
                Console.WriteLine("Voer achternaam in");
                s.Achternaam = Console.ReadLine();
                if (s.Naam == "admin")
                {
                    // doe admin dingen ...
                }
                s.Positie.X = 4;
                s.Positie.Y = 1;
                var level = new Level()
                {
                    Vijandjes = new List<Vijandje>() {
                    new Vijandje() { Positie = new Coordinaat(1, 3) },
                    new Vijandje() { Positie = new Coordinaat(2, 2) },
                    },
                    Muntjes = new List<Muntje>() {
                    new Muntje() { Positie = new Coordinaat(3, 4) },
                    new Muntje() { Positie = new Coordinaat(1, 5) }//maak tenminste 1 keer gebruik van een object initializer
                    }
                };
                level.Teken();
                s.Teken();
                var key = Console.ReadKey();
                while (key.KeyChar != 'q')
                {
                    switch (key.KeyChar)
                    {
                        case 'a': s.Positie = s.Positie + new Coordinaat(-1, 0); break;
                        case 'w': s.Positie = s.Positie + new Coordinaat(0, -1); break;
                        case 's': s.Positie = s.Positie + new Coordinaat(0, 1); break;
                        case 'd': s.Positie = s.Positie + new Coordinaat(1, 0); break;
                    }
                    while (!Console.KeyAvailable)
                    {
                        level.Teken();
                        s.Teken();
                    }
                    key = Console.ReadKey();
                }
            }
            catch (NegatiefTekenenException e)
            {
                Console.WriteLine("Ergens is geprobeerd te tekenen op het negatieve vlak!");
                Console.WriteLine(e);
                Console.WriteLine(s.Volledigenaam + " " +  "u hebt verloren en u heeft zo veel punten: " + s.Punten);
            }
        }
    }
}