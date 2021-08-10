using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly03.Dtos;
using Vidly03.Models;

namespace Vidly03.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);

            var movies = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.Available == 0)
                    return BadRequest("Movie is not available.");

                movie.Available--;

                var newRental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(newRental);
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
