using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;
using AutoMapper;
using OnVideo.Models;
using System.Data.Entity;
using Vidly.Dtos;

namespace OnVideo.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var movieQuery = _context.Movies
                .Include(m => m.Genre)
                .Where(x => x.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                movieQuery = movieQuery.Where(x => x.Name.Contains(query));

            var movieDto = movieQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDto);
        }

        //GET /api/movies/1
        public IHttpActionResult GetMovies(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //POST /api/movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovie)]

        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //PUT api/movies/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovie)]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var moviesInDb = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (moviesInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, moviesInDb);

            moviesInDb.Name = movieDto.Name;
            moviesInDb.NumberInStock = movieDto.NumberInStock;
            moviesInDb.DateReleased = movieDto.DateReleased;
            moviesInDb.DateAdded = movieDto.DateAdded;
            moviesInDb.GenreId = movieDto.GenreId;

            _context.SaveChanges();
        }

        //DELETE /api/movies/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovie)]
        public void DeleteMovie(int id, MovieDto movieDto)
        {
            var moviesInDb = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (moviesInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(moviesInDb);
            _context.SaveChanges();
        }
    }
}
