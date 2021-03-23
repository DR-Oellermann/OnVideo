using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using OnVideo.Dtos;
using OnVideo.Models;

namespace OnVideo.Controllers.Api
{
    public class RentalController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {

            if (newRental.MovieIds.Count == 0)
                return BadRequest("No movie ID's have been given!");

            var customer = _context.Customers
                .SingleOrDefault(x => x.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("Customer ID is not valid!");

            var movies = _context.Movies
                .Where(x => newRental.MovieIds.Contains(x.Id)).ToList();

            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more MovieId's are invalid!");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available!");

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                --movie.NumberAvailable; 
                _context.Rentals.Add(rental);
            }

            return Ok();
        }
    }
}
