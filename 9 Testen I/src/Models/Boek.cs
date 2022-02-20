using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections;

namespace _7_MVC_2.Models
{
    public class Boek
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Auteur { get; set; }
        public string Titel { get; set; }
        public string Genre { get; set; }

        public Boek()
{
}
        public Boek(int id, string isbn, string auteur, string titel, string genre)
        {
            Id = id;
            Isbn = isbn;
            Auteur = auteur;
            Titel = titel;
            Genre = genre;
        }
        public static IEnumerable<Boek> Boeken { get; set; } = new List<Boek>() {
            new Boek(1, "978-7-6512-7309-0", "Wade Dorota Kató", "De mega-explosie", "actie"),
        };
    }
}