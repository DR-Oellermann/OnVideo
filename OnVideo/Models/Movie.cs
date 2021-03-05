using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnVideo.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string  Name { get; set; }

        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }
        [Display(Name = "Released Date")]
        public DateTime DateReleased { get; set; }
        [Display(Name = "Stock Level")]
        [Range(1,20)]
        public byte NumberInStock { get; set; }

    }
}