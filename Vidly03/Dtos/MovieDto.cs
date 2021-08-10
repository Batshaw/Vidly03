using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly03.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

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
        public int NumberInStock { get; set; }

        public GenreDto Genre { get; set; }
    }
}