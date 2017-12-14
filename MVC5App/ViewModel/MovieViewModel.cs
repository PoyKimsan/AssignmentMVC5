using MVC5App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5App.ViewModel
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public string Title {
            get {
                if (Movie != null && Movie.Id != 0)
                    return "Edit Movie";
                return "Add New Movie";
            }
        }
    }
}