using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    [Route("boek/")]
    public class BoekController : Controller
    {
        [HttpGet]
        [Route("aantal/{auteur}")]
        public IActionResult Aantal(string auteur)
        {

            ViewBag.auteur = auteur;
            ViewBag.aantal = Boek.Boeken.Where(b => b.Auteur == auteur).Count();

            return View();
        }

        [HttpGet]
        [Route("genre/{Isbn}")]
        public IActionResult Genre(string Isbn)
        {
            ViewBag.boek = Boek.Boeken.FirstOrDefault(b => b.ISBN == Isbn);

            return View();
        }

        [HttpGet]
        [Route("autheur/{letter}")]
        public IActionResult ZoekAutheur(char letter)
        {

            ViewBag.boeken = Boek.Boeken.Where(b => letter.Equals(b.Auteur[0]));

            ViewBag.letter = letter;

            return View();
        }
    }
}