using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly03.Models;

namespace Vidly03.ViewModels
{
    public class AddMovieViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleasedDate { get; set; }

        [Required]
        [Display(Name = "Number in stock")]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }
        public IEnumerable<Genres> Genres { get; set; }
        public bool AddMovie { get; set; }

        public AddMovieViewModel()
        {
            Id = 0;
        }

        public AddMovieViewModel(Movies movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleasedDate = movie.ReleasedDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

    }
}