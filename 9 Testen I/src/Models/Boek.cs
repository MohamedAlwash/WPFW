using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections;

namespace week9Xunit1.Models
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
    }
}