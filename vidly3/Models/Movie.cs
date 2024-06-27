using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly3.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter movie's name")]
        public string Name { get; set; }

        public MovieGenre MovieGenre { get; set; }

        [Required, Display(Name = "Genre")]
        public byte MovieGenreId { get; set; }

        [Required, Display(Name = "Release date")]
        public DateTime ReleasedDate { get; set; }

        public DateTime AddedDate { get; set; }

        [Required, Range(0, 500), Display(Name = "Number in stock")]
        public int Stock { get; set; }

        public int Available { get; set; }
    }
}