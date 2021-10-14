using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _7_MVC_2.Models;

namespace _7_MVC_2
{
    public class BoekController : Controller
    {
        private readonly BoekDbContext _context;

        public BoekController(BoekDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("aantal/{auteur}")]
        public IActionResult Aantal(string auteur) {

            ViewBag.auteur = auteur;
            ViewBag.aantal = Boek.Boeken.Where(b => b.Auteur.Equals(auteur)).Count(); 

            return View();
        }

        [HttpGet]
        [Route("genre/{isbn}")]
        public IActionResult Genre(string isbn) {
            foreach(Boek boeken in Boek.Boeken) {
                if(boeken.Isbn == isbn) ViewBag.genre = boeken.Genre;
            
            }
            ViewBag.genre = ViewBag.genre != null ? ViewBag.genre  : "Deze isbn komt niet voor in de lijst.";
            return View();
        }

        [HttpGet]
        [Route("zoekauteur/{letter}")]
        public IActionResult ZoekAuteur(char letter) {

            ViewBag.selectedLetter = letter;

            var filteredAuteurs = ViewBag.auteurs = Boek.Boeken.Where(b => letter.Equals(b.Auteur[0])).ToList();
            
            foreach(Boek boeken in filteredAuteurs) {
                ViewBag.selectedAuteurs = boeken.Auteur;
            }
            return View();
        }

        // GET: Boek
        public async Task<IActionResult> Index()
        {
            return View(await _context.Boeken.ToListAsync());
        }

        // GET: Boek/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boek = await _context.Boeken
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boek == null)
            {
                return NotFound();
            }

            return View(boek);
        }

        // GET: Boek/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Temp/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Isbn, Auteur,Titel,Genre")] Boek boek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boek);
        }

        // GET: Boek/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boek = await _context.Boeken.FindAsync(id);
            if (boek == null)
            {
                return NotFound();
            }
            return View(boek);
        }

        // POST: Boek/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Auteur,Titel,Genre")] Boek boek)
        {
            if (id != boek.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoekExists(boek.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(boek);
        }

        // GET: Boek/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boek = await _context.Boeken
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boek == null)
            {
                return NotFound();
            }

            return View(boek);
        }

        // POST: Boek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boek = await _context.Boeken.FindAsync(id);
            _context.Boeken.Remove(boek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoekExists(int id)
        {
            return _context.Boeken.Any(e => e.Id == id);
        }
    }
}
