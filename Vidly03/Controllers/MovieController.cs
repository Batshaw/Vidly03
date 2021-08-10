using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly03.Models;
using System.Data.Entity;
using Vidly03.ViewModels;

namespace Vidly03.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movie
        public ActionResult Index()
        {
            //var movies = _context.Movies.Include(m => m.Genre).ToList();
            
            //return View(movies);
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Index");
            
            return View("ReadOnlyIndex");
        }

        public ActionResult MovieDetails(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult AddMovieForm()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new AddMovieViewModel
            {
                Genres = genres,
                AddMovie = true
            };
            
            return View(viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movies movies)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AddMovieViewModel(movies)
                {
                    Genres = _context.Genres,
                    AddMovie = true
                };

                return View("AddMovieForm", viewModel);
            }
            if (movies.Id == 0)
            {
                movies.AddedDate = DateTime.Today;
                movies.Genre = _context.Genres.Single(g => g.Id == movies.GenreId);
                _context.Movies.Add(movies);
            }
            else
            {
                var movieInDbase = _context.Movies.Single(m => m.Id == movies.Id);
                movieInDbase.Name = movies.Name;
                movieInDbase.NumberInStock = movies.NumberInStock;
                movieInDbase.Genre = movies.Genre;
                movieInDbase.GenreId = movies.GenreId;
            }
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Movie");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new AddMovieViewModel(movie)
            {
                Genres = _context.Genres,
                AddMovie = false
            };

            return View("AddMovieForm", viewModel);
        }
    }
}