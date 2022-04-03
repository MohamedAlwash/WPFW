using System;

namespace LeerlingAdministratie
{
    public class Leerling
    {
        public string Naam { get; set; }
        public IAdministratie Administratie { get; }

        public Leerling(string naam, IAdministratie administratie)
        {
            this.Naam = naam;
            this.Administratie = administratie;
        }

        public void UpdateCijfers(float nieuweCijfer)
        {
            Administratie.UpdateCijfers(nieuweCijfer);
        }

        public void UpdateBeoordeling(string nieuweBeoordeling)
        {
            Administratie.UpdateBeoordeling(nieuweBeoordeling);
        }

        public void IsAfwezig(string redeAfwezigheid)
        {
            int randomAantalKerenAfwezig = 3;

            IDataLeerling dataLeerling = new DataLeerling()
            {
                AantalKerenAfwezig = randomAantalKerenAfwezig,
                RedeVanLaatsteAfwezigheid = redeAfwezigheid,
            };

            // Ministerie vewacht de data in twee vormen
            Administratie.StuurDataNaarMinisterieVanOnderwijs(redeAfwezigheid, randomAantalKerenAfwezig);
            Administratie.StuurDataNaarMinisterieVanOnderwijsAlsObject(dataLeerling);

        }

        public IDataLeerling VraagDataOpVanMinisterieVanOnderwijs()
        {
            var dataLeerling = Administratie.VraagDataOpVanMinisterieVanOnderwijs(Naam);
            return dataLeerling;
        }

        public static void Main(string[] args)
        {
            Leerling eve = new Leerling("Eve", new Administratie());
            eve.UpdateCijfers(7);
            eve.UpdateBeoordeling("Hartstikke goed gedaan!");
            eve.IsAfwezig("Ziek");
            eve.IsAfwezig("Geen zin");
            Leerling bob = new Leerling("Bob", new Administratie());
            Console.WriteLine("Bob is " + bob.VraagDataOpVanMinisterieVanOnderwijs().AantalKerenAfwezig + " keer afwezig geweest");
        }
    }

    public interface IAdministratie
    {
        int AantalKerenAfwezig { get; set; }
        string RedeVanLaatsteAfwezigheid { get; set; }

        void UpdateBeoordeling(string nieuweBeoordeling);
        void UpdateCijfers(float nieuweCijfer);
        bool StuurDataNaarMinisterieVanOnderwijs(string redeVanLaatsteAfwezigheid, int aantalKerenAfwezig);
        bool StuurDataNaarMinisterieVanOnderwijsAlsObject(IDataLeerling dataLeerling);
        IDataLeerling VraagDataOpVanMinisterieVanOnderwijs(string NaamLeering);
    }


    public class Administratie : IAdministratie
    {
        public int AantalKerenAfwezig { get; set; }
        public string RedeVanLaatsteAfwezigheid { get; set; }

        private string beoordeling { get; set; }
        private float cijfer { get; set; }

        public void UpdateBeoordeling(string nieuweBeoordeling)
        {
            beoordeling = nieuweBeoordeling;
        }
        public void UpdateCijfers(float nieuweCijfer)
        {
            cijfer = nieuweCijfer;
        }
        public bool StuurDataNaarMinisterieVanOnderwijs(string redeVanLaatsteAfwezigheid, int aantalKerenAfwezig)
        {
            Console.WriteLine("Informatie wordt verstuurd naar het ministerie...");
            // ...
            Console.WriteLine("Informatie is verstuurd!");
            return true;
        }
        public bool StuurDataNaarMinisterieVanOnderwijsAlsObject(IDataLeerling dataLeerling)
        {
            Console.WriteLine("Informatie wordt *als object* verstuurd naar het ministerie...");
            // ...
            Console.WriteLine("Informatie is verstuurd!");
            return true;
        }
        public IDataLeerling VraagDataOpVanMinisterieVanOnderwijs(string NaamLeering)
        {
            if (NaamLeering == "Alice")
                return new DataLeerling { AantalKerenAfwezig = 2, RedeVanLaatsteAfwezigheid = "Corona" };
            if (NaamLeering == "Bob")
                return new DataLeerling { AantalKerenAfwezig = 3, RedeVanLaatsteAfwezigheid = "Corona" };
            return new DataLeerling { AantalKerenAfwezig = 0, RedeVanLaatsteAfwezigheid = "" };
        }
    }

    public class DataLeerling : IDataLeerling
    {
        public int AantalKerenAfwezig { get; set; }
        public string RedeVanLaatsteAfwezigheid { get; set; }
    }

    public interface IDataLeerling
    {
        int AantalKerenAfwezig { get; set; }
        string RedeVanLaatsteAfwezigheid { get; set; }
    }
}

