using System;
using System.Collections.Generic;
using System.Globalization;

namespace ORM_Opdracht
{
    class Program
    {
        private Verhuurder _verhuurder;
        private Huurder _huurder;
        MyDatabase db = new MyDatabase();

        static void Main(string[] args)
        {
            // MyDatabase.DummyData(); //create dummy data
            Program p = new Program();
            p.autoHuren();
        }

        public void login()
        {
            Console.WriteLine("Wat is uw email?");
            String email = Console.ReadLine();
            Boolean accessGrantedVerhuurder = false;
            Boolean accessGrantedHuurder = false;


            foreach (Verhuurder verhuurder in db.Verhuurder)
            {
                if (verhuurder.Email.Equals(email))
                {
                    Console.WriteLine("Welkom " + verhuurder.Naam);
                    _verhuurder = verhuurder;
                    accessGrantedVerhuurder = true;
                }
            }

            foreach (Huurder huurder in db.Huurder)
            {
                if (huurder.Email.Equals(email))
                {
                    Console.WriteLine("Welkom " + huurder.Naam);
                    _huurder = huurder;
                    accessGrantedHuurder = true;
                }
            }

            if (accessGrantedVerhuurder)
            {
                autoToevoegen();
            }
            else if (accessGrantedHuurder)
            {
                autoHuren();
            }
            else
            {
                Console.WriteLine("Onjuiste email, probeer het opnieuw");
                login();
            }
        }

        public void autoToevoegen()
        {
            Console.WriteLine("Welke auto wilt u toevoegen?");
            String autoMerk = Console.ReadLine();
            db.Auto.Add(new Auto()
            {
                Merk = autoMerk,
            });
            db.SaveChanges();
            Console.WriteLine("Auto succesvol toegevoegd!");
        }

        public void autoHuren()
        {

            CultureInfo provider = CultureInfo.InvariantCulture;

            Console.WriteLine("Wanneer wilt u een auto huren?");
            DateTime beginDatum = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm:ss", provider);

            Console.WriteLine("Voor hoeveel uur wilt u de auto huren?");
            TimeSpan duratie = TimeSpan.Parse(Console.ReadLine() + ":00:00");

            DateTime eindDatum = beginDatum.Add(duratie);
            Console.WriteLine(eindDatum);

            Console.WriteLine("Uw mogelijkheden bestaan uit: ");

            List<Auto> autos = new List<Auto> { };



            foreach (Auto auto in db.Auto)
            {
                autos.Add(auto);
            }

            foreach (Auto auto in autos)
            {
                foreach (HuurContract huurcontract in db.HuurContract)
                {
                    if (auto.Id == huurcontract.AutoId)
                    {
                        if (huurcontract.EindDatum < eindDatum)
                        {
                            Console.WriteLine(auto.Id + " " + auto.Merk);
                        }
                    }
                    else if (auto.Id != huurcontract.AutoId)
                    {
                        Console.WriteLine(auto.Id + " " + auto.Merk);
                    }
                }
            }

            Console.WriteLine("Selecteer uw keuze: ");
            int getal = Convert.ToInt32(Console.ReadLine());
            db.HuurContract.Add(new HuurContract()
            {
                HuurderId = _huurder.Id,
                AutoId = autos[getal].Id,
                BeginDatum = beginDatum,
                EindDatum = eindDatum,
            });
            db.SaveChanges();
            Console.WriteLine("Boeking is gedaan");
        }
    }
}
