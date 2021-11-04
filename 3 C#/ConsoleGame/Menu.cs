using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    static class menu //maak tenminste 1 zinvolle nieuwe klasse aan
    {
        public static void start()
        {
            Console.WriteLine("Welkom bij mijn game!");
            Console.WriteLine("Kies een optie uit de volgende menu");
            Console.WriteLine("1) Start de game");
            Console.WriteLine("2) Bekijk de high score");
            Console.WriteLine("3) Verlaat de game");
            int keuze = Int16.Parse(Console.ReadLine());
            if (1 == keuze)
            {
                Console.WriteLine("Voer naam in");
            }
            else if (2 == keuze)
            {
                bekijkHighScore();
            }
            else if (3 == keuze)
            {
                System.Environment.Exit(1);
            }
        }

        public static void bekijkHighScore()
        {
            List<Speler> Spelers = new List<Speler>() {
                new Speler() { Naam = "Mohamed", Achternaam = "Alwash", Punten = 10},
                new Speler() { Naam = "Ramon", Achternaam = "vanDerBoom", Punten = 20}
            };

            Spelers.ForEach(s => System.Console.WriteLine("{0} heeft {1} punten", s.Volledigenaam, s.Punten));
            menu.start();
        }
    }
}