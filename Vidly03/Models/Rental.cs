using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly03.Models
{
    public class Rental
    {
        public int Id { get; set; }

        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }

        [Required]
        public Customers Customer { get; set; }

        [Required]
        public Movies Movie { get; set; }
    }
}