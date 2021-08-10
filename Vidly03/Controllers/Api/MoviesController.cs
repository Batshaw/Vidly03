using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly03.Dtos;
using Vidly03.Models;
using System.Data.Entity;

namespace Vidly03.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.Available > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            var movieDto = moviesQuery
                .ToList()
                .Select(Mapper.Map<Movies, MovieDto>);

            return Ok(movieDto);
        }

        // GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movies, MovieDto>(movie));
        }

        // POST /api/moives
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movies>(movieDto);
            movie.AddedDate = DateTime.Today;
            movie.Genre = _context.Genres.Single(g => g.Id == movie.GenreId);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT /api/movies/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDbase = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDbase == null)
                return NotFound();

            Mapper.Map(movieInDbase, movieDto);
            _context.SaveChanges();

            return Ok();
        }


        // DELETE /api/movies/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDbase = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDbase == null)
                return NotFound();

            _context.Movies.Remove(movieInDbase);
            _context.SaveChanges();

            return Ok();
        }
    }
}
