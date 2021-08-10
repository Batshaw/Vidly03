using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly03.Models
{
    public class Movies
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genres Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        
        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleasedDate { get; set; }

        [Required]
        public DateTime AddedDate { get; set; }

        [Required]
        [Display(Name = "Number in stock")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        public byte Available { get; set; }
    }
}