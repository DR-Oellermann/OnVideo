using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
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

        public ViewResult Index()
        {
            if (User.IsInRole("CanManageMovie"))
                return View("Index");

            return View("ReadOnlyList");

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

            var viewModel = new MoviesFormViewModel(movie)
            {
                Genres = _context.GenreTypes.ToList()
            };

            return View("MoviesForm", viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MoviesFormViewModel(movie)
                {
                    Genres = _context.GenreTypes.ToList()
                };

                return View("MoviesForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var moviesInDb = _context.Movies.Single(x => x.Id == movie.Id);
                moviesInDb.Name = movie.Name;
                moviesInDb.DateReleased = movie.DateReleased;
                moviesInDb.NumberInStock = movie.NumberInStock;
                moviesInDb.GenreId = movie.GenreId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return View();
        //}
    }
}