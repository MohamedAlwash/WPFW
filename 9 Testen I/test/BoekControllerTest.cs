using Xunit;
using week9Xunit1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using week9Xunit1.Models;
using week9Xunit1.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace test
{
    public class BoekControllerTest
    {
        private readonly BoekDbContext _context;
        private BoekController _controller;

        public BoekControllerTest()
        {
            _context = GetContextWithData();
            _controller = new BoekController(_context);
        }

        private BoekDbContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<BoekDbContext>()
                              .UseInMemoryDatabase(Guid.NewGuid().ToString())
                              .Options;
            var context = new BoekDbContext(options);

            context.Boeken.AddRange(
                new Boek { Id = 1, Isbn = "9781234567897", Auteur = "Mohamed", Titel = "Titel1", Genre = "Poetry" },
                new Boek { Id = 2, Isbn = "9784446615950", Auteur = "Kees", Titel = "Titel2", Genre = "Drama" },
                new Boek { Id = 3, Isbn = "9785908837293", Auteur = "Ali", Titel = "Titel3", Genre = "Prose" },
                new Boek { Id = 4, Isbn = "9781234567897", Auteur = "Gijs", Titel = "Titel4", Genre = "Nonfiction" }
                );

            context.SaveChanges();

            return context;
        }

        [Fact]
        public void AantalTest()
        {
            int expected = _context.Boeken.Where(b => b.Auteur.Equals("Mohamed")).Count();
            var viewResult = Assert.IsType<ViewResult>(_controller.Aantal("Mohamed"));
            Assert.Equal(expected, viewResult.ViewData["aantal"]);

        }

        [Fact]
        public void GenreTest()
        {
            Boek expected = _context.Boeken.FirstOrDefault<Boek>(b => b.Isbn.Equals("9781234567897"));
            var viewResult = Assert.IsType<ViewResult>(_controller.Genre("9781234567897"));
            Assert.Equal(expected, viewResult.ViewData["genre"]);
        }

        [Fact]
        public void ZoekAuteurTest()
        {
            List<Boek> auteurs = new List<Boek>();
            foreach (Boek boek in _context.Boeken)
            {
                if ('K'.Equals(boek.Auteur[0]))
                {
                    auteurs.Add(boek);
                }
            }

            var viewResult = Assert.IsType<ViewResult>(_controller.ZoekAuteur('K'));
            Assert.Equal(auteurs, viewResult.ViewData["auteurs"]);
        }

        [Fact]
        public async void CreateTestSucces()
        {
            Boek newBoek = new Boek() { Id = 5, Isbn = "18046533", Auteur = "Karel", Titel = "Titel5", Genre = "Poetry" };

            var result = await _controller.Create(newBoek);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.Equal(_context.Boeken.Last(), newBoek);
            Assert.Null(redirectToActionResult.ControllerName);
        }

        [Fact]
        public async void CreateTestFail() // luk niet om modelstate failen
        {
            Boek newBoek = new Boek() { Id = 5, Auteur = "Karel", Titel = "Titel5", Genre = "Poetry" };

            _controller.ModelState.AddModelError("Error", "Isbn is missing");
            var result = await _controller.Create(newBoek);

            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public async void EditTest()
        {
            Boek newBoek = new Boek() { Id = 1, Isbn = "18046533", Auteur = "Karel", Titel = "Mohamed", Genre = "Poetry" };

            Boek expected = await _context.Boeken.FirstAsync();

            var result = await _controller.Edit(newBoek.Id, expected);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.Null(redirectToActionResult.ControllerName);
        }
    }
}