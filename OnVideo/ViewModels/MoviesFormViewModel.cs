using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnVideo.Models;

namespace OnVideo.ViewModels
{
    public class MoviesFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}