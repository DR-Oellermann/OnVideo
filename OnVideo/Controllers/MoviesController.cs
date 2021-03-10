﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnVideo.Models;
using OnVideo.ViewModels;

namespace OnVideo.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek"};


            return View(movie);

        }

        public ActionResult Index()
        {
            var movie = _context.Movies.Include(m => m.Genre).ToList();

            //var movie = new Movie() { Name = "Shrek" };

            return View(movie);
        }

        public ActionResult Details(int id)
        {

            var details = _context.Movies.Include(g => g.Genre).SingleOrDefault(x => x.Id == id);

            if (details == null)
            {
                return HttpNotFound();
            }
            return View(details);

        }

        public ActionResult NewMovie()
        {
            var genreTypes = _context.GenreTypes.ToList();
            var viewModel = new MoviesFormViewModel()
            {
                Genres = genreTypes
            };

            return View("MoviesForm", viewModel);
        }

        public ActionResult EditMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MoviesFormViewModel
            {
                Movie = movie,
                Genres = _context.GenreTypes.ToList()
            };

            return View("MoviesForm", viewModel);

        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            return RedirectToAction("Index");
        }

        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return View();
        //}
    }
}