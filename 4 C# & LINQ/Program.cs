using System;
using System.Linq;
using System.Collections.Generic;

namespace _4_C____LINQ
{
    public class Student
    {
        public string Naam { get; set; }

        public int Geboortejaar { get; set; }

        public string Klas { get; set; }

        public string Geslacht { get; set; }

        public override string ToString()
        {
            return "Student[" + Naam + "," + Geboortejaar.ToString() + "," + Klas + "," + Geslacht + "]";
        }

        public static IList<Student> Studenten = new List<Student>
        {
            new Student{Naam = "John", Geboortejaar = 1968, Klas = "1A", Geslacht = "Man"},
            new Student{Naam = "Klaas", Geboortejaar = 1980, Klas = "3B", Geslacht = "Genderneutraal"},
            new Student{Naam = "Mohammed", Geboortejaar = 1989, Klas = "2A", Geslacht = "Vrouw"},
            new Student{Naam = "Christus", Geboortejaar = 1998, Klas = "1A", Geslacht = "Man"},
            new Student{Naam = "Jan", Geboortejaar = 1982, Klas = "3B", Geslacht = "Man"},
            new Student{Naam = "Jaap", Geboortejaar = 1969, Klas = "3B", Geslacht = "Geheim"},
            new Student{Naam = "Joep", Geboortejaar = 1968, Klas = "2A", Geslacht = "Genderfluid"},
            new Student{Naam = "Hans", Geboortejaar = 1957, Klas = "1A", Geslacht = "Vrouw"},
            new Student{Naam = "John", Geboortejaar = 1971, Klas = "1A", Geslacht = "Vrouw"},
            new Student{Naam = "Tim", Geboortejaar = 1975, Klas = "2A", Geslacht = "Vrouw"},
            new Student{Naam = "Brazil", Geboortejaar = 1985, Klas = "3A", Geslacht = "Man"},
            new Student{Naam = "Hans", Geboortejaar = 1988, Klas = "3B", Geslacht = "Vrouw"},
            new Student{Naam = "Tom", Geboortejaar = 1968, Klas = "1A", Geslacht = "Genderfluid"},
            new Student{Naam = "Pim", Geboortejaar = 2012, Klas = "2B", Geslacht = "Vrouw"},
            new Student{Naam = "Ubud", Geboortejaar = 1997, Klas = "2A", Geslacht = "Vrouw"},
            new Student{Naam = "Julia", Geboortejaar = 1965, Klas = "2A", Geslacht = "Genderfluid"},
            new Student{Naam = "Romeo", Geboortejaar = 1991, Klas = "3B", Geslacht = "Vrouw"},
            new Student{Naam = "John", Geboortejaar = 2002, Klas = "2B", Geslacht = "Non-binair"}
        };

        public static void Opdrachten()
        {
            // Opdracht1(); // completed
            // Opdracht2(); // completed
            // Opdracht3(); // completed
            // Opdracht4(); // completed
            // Opdracht5(); // completed
            // Opdracht6(); // completed
        }

        static void Opdracht1() // Toon van alle studenten de naam en het geboortejaar, gesorteerd het geboortejaar.
        {
            Studenten.OrderBy(student => student.Geboortejaar).ToList().ForEach(student => Console.WriteLine("{0} - {1}", student.Naam, student.Geboortejaar));
        }

        static void Opdracht2() // In welk jaar is de jongste student geboren in klas 2A?
        {
            Console.WriteLine(Studenten.Where(s => s.Klas == "2A").Max(s => s.Geboortejaar));
        }

        static void Opdracht3() // Hoeveel vrouwen zitten er in klas 1A?
        {
            Console.WriteLine(Studenten.Where(s => s.Geslacht == "Vrouw").Count());
        }

        static void Opdracht4() // Toon de 6e t/m 10e student uit de lijst.
        {
            List<Student> nieuwStudenten = new List<int> { 5, 6, 7, 8, 9 }.Select(x => Studenten[x]).ToList();
            foreach (Student student in nieuwStudenten) Console.WriteLine(student.ToString());
        }

        static void Opdracht5() // Is er een student uit 1997 (True/False)?
        {
            Console.WriteLine(Studenten.Any(x => x.Geboortejaar == 1997));
        }

        static void Opdracht6() // In welke klas zit Joep?
        {
            Studenten.Where(s => s.Naam == "Joep").ToList().ForEach(x => Console.WriteLine(x.ToString()));
        }
    }

    public class BlackBoardPagina
    {
        public string URL { get; set; }

        public override string ToString()
        {
            return "Pagina[" + URL.ToString() + "]";
        }

        public static BlackBoardPagina Home = new BlackBoardPagina() { URL = "blackboard.nl" };
        public static BlackBoardPagina Sem2 = new BlackBoardPagina() { URL = "blackboard.nl/sem2" };
        public static BlackBoardPagina AgileOO = new BlackBoardPagina() { URL = "blackboard.nl/agile" };
        public static BlackBoardPagina Sem3 = new BlackBoardPagina() { URL = "blackboard.nl/sem3" };
        public static BlackBoardPagina WPFW = new BlackBoardPagina() { URL = "blackboard.nl/wpfw" };
        public static BlackBoardPagina Wikipedia = new BlackBoardPagina() { URL = "wikipedia.nl/" };
    }

    public class Bezoek
    {
        public Student Student { get; set; }
        public BlackBoardPagina Pagina { get; set; }
        public int Duur { get; set; }
        public List<Bezoek> DoorgekliktNaar { get; set; }
        public override string ToString()
        {
            return "Bezoek[" + Student.ToString() + "," + Pagina.ToString() + "," + Duur.ToString() + "]";
        }
        // De lijst `bezoekjes` bevat alle bezoekjes van studenten aan blackboard pagina's. 
        public static List<Bezoek> bezoekjes = null;
        static Bezoek()
        {
            Bezoek b1 = new Bezoek() { Student = Student.Studenten[0], Duur = 30, Pagina = BlackBoardPagina.Home };
            Bezoek b2 = new Bezoek() { Student = Student.Studenten[0], Duur = 130, Pagina = BlackBoardPagina.Sem3 };
            Bezoek b3 = new Bezoek() { Student = Student.Studenten[0], Duur = 342, Pagina = BlackBoardPagina.WPFW };
            Bezoek b4 = new Bezoek() { Student = Student.Studenten[0], Duur = 5, Pagina = BlackBoardPagina.Sem2 };
            Bezoek b5 = new Bezoek() { Student = Student.Studenten[1], Duur = 25, Pagina = BlackBoardPagina.Home };
            Bezoek b6 = new Bezoek() { Student = Student.Studenten[1], Duur = 394, Pagina = BlackBoardPagina.Sem2 };
            Bezoek b7 = new Bezoek() { Student = Student.Studenten[1], Duur = 23, Pagina = BlackBoardPagina.Sem3 };
            Bezoek b8 = new Bezoek() { Student = Student.Studenten[1], Duur = 115, Pagina = BlackBoardPagina.WPFW };
            Bezoek b9 = new Bezoek() { Student = Student.Studenten[1], Duur = 29, Pagina = BlackBoardPagina.AgileOO };
            b1.DoorgekliktNaar = new List<Bezoek> { b2, b4 };
            b2.DoorgekliktNaar = new List<Bezoek> { b3 };
            b5.DoorgekliktNaar = new List<Bezoek> { b6 };
            b6.DoorgekliktNaar = new List<Bezoek> { b7, b9 };
            b7.DoorgekliktNaar = new List<Bezoek> { b8 };
            bezoekjes = new List<Bezoek> { b1, b2, b3, b4, b5, b6, b7, b8, b9 };
        }

        public static void Opdrachten()
        {
            // Opdracht1(); // op de helft
            // Opdracht2(); // completed
            Opdracht3();
            // Opdracht4();
            // Opdracht5();
            // Opdracht6();
        }

        static void Opdracht1() // Hoe vaak hebben de studenten in totaal doorgeklikt?.
        {
            bezoekjes.ForEach(x => Console.WriteLine(x.DoorgekliktNaar?.Count()));
        }

        static void Opdracht2() // We willen in een console een lijst te zien krijgen van bezoekjes korter dan 1 minuut. Gebruik de ToString in Bezoek. Tip: gebruik Where, ToList en daarna ForEach. Waarom bestaat ForEach niet in LINQ?
        {
            bezoekjes.Where(x => x.Duur <= 60).ToList().ForEach(x => Console.WriteLine(x.ToString()));
        }

        static void Opdracht3() // We willen een lijst van pagina's die tenminste twee keer zijn bezocht
        {
            // List<BlackBoardPagina> paginasTenminsteTweeKeerBezocht = bezoekjes.Where(x => x.Pagina == BlackBoardPagina.AgileOO || x.Pagina == BlackBoardPagina.Home || x.Pagina == BlackBoardPagina.Sem2 || x.Pagina == BlackBoardPagina.Sem3 || x.Pagina == BlackBoardPagina.Wikipedia || x.Pagina == BlackBoardPagina.WPFW);
        }

        static void Opdracht4() // Print van elke student uit hoeveel verschillende pagina's hij/zij heeft bezocht. Tip: kijk uit dat je meerdere bezoekjes van een student aan dezelfde pagina niet dubbel telt! Tip: gebruik Distinct. Tip: gebruik een anonieme type. 
        {
            // foreach (var i in bezoekjes)
            // Console.WriteLine("Student " + i.Student + " heeft " + i.Aantal + " verschillende pagina's bezocht. ");
        }

        static void Opdracht5() // Geef alternatieve LINQ die sneller werkt.
        {
            if (bezoekjes.Where((b) => b.Duur > 100).ToList().Any())
                Console.WriteLine("Er is een lang bezoek geweest. ");
        }


        static void Opdracht6() // Zet de top drie meest ijverige studenten in een IEnumerable. Een student is ijveriger dan een andere student als deze meer paginas heeft bekeken. Tip: kopieer je antwoord bij Opdracht4
        {
            // IEnumerable<Student> ijverigeStudenten = bezoekjes;
        }
    }

    public static class LosseOpgaven
    {
        public static void Opdrachten()
        {
            Opdracht1();
            Opdracht2();
            Opdracht3();
            Opdracht4();
            Opdracht5();
        }

        static void Opdracht1() // De gebruiker voert een zin in, en die zin wordt vervolgens opgesplitst in woorden. Bedenk welke LINQ er op de plaats van de puntjes terecht moet komen om de oorspronkelijke zin weer terug te krijgen. 
        {
            string zin = "Wie dit leest is gek";
            string[] woorden = zin.Split(" ");
            zin = null;
            // zin = woorden;
            Console.WriteLine(zin);
        }

        static void Opdracht2() // Wat moet er op de plaats van de puntjes komen te staan om de getallen uit de lijst die hetzelfde zijn als het getal ervoor eruit te filteren?
        {
            List<int> getallen = new List<int> { 4, 6, 6, 3, 2, 5, 5, 3, 5, 3, 3, 7, 8 };
            foreach (int i in getallen.Aggregate(new List<int>(), (a, b) =>
            {
                return a;
            }))
                Console.WriteLine(i);
            // De uitvoer hoort 4, 6, 3, 2, 5, 3, 5, 3, 7, 8 te zijn. 
        }

        static void Opdracht3() // Houd er rekening mee dat de getallen in de lijst flink van grootte verschillen en dat double een eindige precisie heeft. Bereken het totaal en print het resultaat. Tip: maakt de volgorde uit waarin de getallen worden opgeteld?
        {
            List<double> getallen = new List<double>();
            getallen.Add(100000000000000000.0);
            for (int i = 0; i < 1000000; i++) getallen.Add(1);
            // double totaal = getallen;
            // Console.WriteLine(totaal);
        }

        static void Opdracht4() // Gegeven is een lijst `tijden` van tijdstippen waarop de lichtschakelaar is ingedrukt. Bereken hoe lang het licht aan heeft gestaan in LINQ, door gebruik te maken van Aggregate. Het licht stond uit voor de eerste item. Deze vraag is erg moeilijk! Tip: maak een helper klasse aan. 
        {
            List<DateTime> tijden = new List<DateTime>
        {
            new DateTime(2021, 3, 4, 9, 0, 3),
            new DateTime(2021, 3, 4, 10, 20, 35),
            new DateTime(2021, 3, 4, 15, 2, 22),
            new DateTime(2021, 3, 4, 16, 1, 0),
            new DateTime(2021, 3, 4, 16, 55, 48),
            new DateTime(2021, 3, 4, 22, 40, 12)
        };
            // int totaalAantalSecondenAan = tijden;
        }

        static void Opdracht5() // Omdat lambda expressies variabelen kunnen capturen van buiten de lambda expressie, is het mogelijk om te tellen met een ForEach. Zonder uitvoeren van de code, wat denk je dat er wordt geprint? Waarom? Is jouw antwoord hetzelfde als de Select wordt vervangen door ForEach?
        {
            int i = 0;
            Student.Studenten.Select((student) => i++);
            Console.WriteLine(i);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Student.Opdrachten();
            Bezoek.Opdrachten();
            // LosseOpgaven.Opdrachten();
        }
    }
}