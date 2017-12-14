using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5App.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleasedDate { get; set; } = DateTime.Now;
        public DateTime AddedDate { get; set; }

        [Display(Name = "In Stock")]
        [Range(1,20)]
        public int NumberInstock { get; set; } = 0;
        public Genre Genre { get; set; }

        [Required]
        [Display(Name ="Genre")]
        public int GenreId { get; set; }
    }
}