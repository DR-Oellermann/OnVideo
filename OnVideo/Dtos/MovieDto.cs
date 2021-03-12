using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using OnVideo.Models;

namespace OnVideo.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's Name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Genre is required!")]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }
        [Display(Name = "Released Date")]
        public DateTime DateReleased { get; set; }

        [Required(ErrorMessage = "Number in stock required!")]
        [Display(Name = "Stock Level")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }
    }
}