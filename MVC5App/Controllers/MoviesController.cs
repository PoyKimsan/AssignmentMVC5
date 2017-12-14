using MVC5App.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5App.ViewModel;

namespace MVC5App.Controllers
{
    public class MoviesController : Controller
    {
        public ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList() ;
            return View(movies);
        }
        public ActionResult Details(int id) {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }
        public ActionResult AddNew() {
            var genre = _context.Genres.ToList();
            var viewModel = new MovieViewModel() {
                Movie = new Movie(),
                Genres = genre
            };
            return View("MovieForm", viewModel);
        }
        public ActionResult Edit(int id) {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            var movieView = new MovieViewModel() {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", movieView);
        }
        [HttpPost]
        public ActionResult Save(Movie movie) {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel() {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.AddedDate = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else{
                var MovieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
                MovieInDb.Name = movie.Name;
                MovieInDb.ReleasedDate = movie.ReleasedDate;
                MovieInDb.NumberInstock = movie.NumberInstock;
                MovieInDb.GenreId = movie.GenreId;
                movie.AddedDate = DateTime.Now;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");

        }
    }
}