using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnVideo.Models;

namespace OnVideo.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek"};


            return View(movie);

        }

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return View();
        //}
    }
}