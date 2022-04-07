﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncBoekOpdracht
{
    class Boek
    {
        public string Titel { get; set; }
        public string Auteur { get; set; }

        public async Task<float> AIScore()
        {
            double ret = 1.0f;
            await Task.Run(() =>
            {
                for (int i = 0; i < 10000000; i++)
                    for (int j = 0; j < 10; j++)
                        ret = (ret + Willekeurig.Random.NextDouble()) % 1.0;
            });
            return (float)ret;
        }
    }
    static class Willekeurig
    {
        public static Random Random = new Random();
        public static async Task Vertraging(int MinAantalMs = 500, int MaxAantalMs = 1000)
        {
            await Task.Delay(Random.Next(MinAantalMs, MaxAantalMs));
        }
    }
    static class Database
    {
        private static List<Boek> lijst = new List<Boek>();
        public static async void VoegToe(Boek b)
        {
            await Willekeurig.Vertraging(); // INSERT INTO ...
            lijst.Add(b);
        }
        public static async Task<List<Boek>> HaalLijstOp()
        {
            await Willekeurig.Vertraging(); // SELECT * FROM ...
            return lijst;
        }
        public static async void Logboek(string melding)
        {
            await Willekeurig.Vertraging(); // schrijf naar logbestand
        }
    }
    class Program
    {
        static async Task VoegBoekToe()
        {
            Console.WriteLine("Geef de titel op: ");
            var titel = Console.ReadLine();
            Console.WriteLine("Geef de auteur op: ");
            var auteur = Console.ReadLine();
            Database.VoegToe(new Boek { Titel = titel, Auteur = auteur });
            Database.Logboek("Er is een nieuw boek!");
            Console.WriteLine("De huidige lijst met boeken is: ");
            foreach (var boek in await Database.HaalLijstOp())
            {
                Console.WriteLine(boek.Titel);
            }
        }
        static async void ZoekBoek()
        {
            Console.WriteLine("Waar gaat het boek over?");
            var beschrijving = Console.ReadLine();
            Boek beste = null;
            foreach (var boek in await Database.HaalLijstOp())
            {
                if (await boek.AIScore() > await beste?.AIScore())
                {
                    beste = boek;
                }
                else
                {
                    beste.Titel = "Not Available";
                }
            }
            Console.WriteLine("Het boek dat het beste overeenkomt met de beschrijving is: ");
            Console.WriteLine(beste.Titel);
        }
        static bool Backupping = false;
        // "Backup" kan lang duren. We willen dat de gebruiker niet hoeft te wachten, 
        // en direct daarna boeken kan toevoegen en zoeken. 
        static async Task Backup()
        {
            if (Backupping)
                return;
            Backupping = true;
            await Willekeurig.Vertraging(2000, 3000);
            Backupping = false;
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welkom bij de boeken administratie!");
            string key = null;
            while (key != "q")
            {
                Console.WriteLine("+) Boek toevoegen");
                Console.WriteLine("z) Boek zoeken");
                Console.WriteLine("b) Backup maken van de boeken");
                Console.WriteLine("q) Quit");
                key = Console.ReadLine();
                if (key == "+")
                    await VoegBoekToe();
                else if (key == "z")
                    ZoekBoek();
                else if (key == "b")
                    Backup();
                else Console.WriteLine("Ongeldige invoer!");
            }
        }
    }
}