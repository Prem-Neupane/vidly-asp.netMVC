using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
         private readonly ApplicationDbContext _context;

        public MoviesController()
        {
                _context = new ApplicationDbContext();
        }

        //override dispose + tab
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            //var movies = _context.Movies.Include(p => p.MovieGenre).ToList(); //dont forget to add Data Entity -> using System.Data.Entity;
            //return View(movies);

            var viewModel = new RandomMovieViewModel
            {
                Movies = _context.Movies.Include(p => p.MovieGenre).ToList()
            };
            return View(viewModel);
        }


        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(p => p.MovieGenre).SingleOrDefault(p => p.Id == id);
            if (movie == null) return HttpNotFound();

            return View(movie);
        }


            //--------------------------------old code---------------------------------------------------
            // GET: Movies
            //public ActionResult Random()
            //{

            //    var movies = new List<Movie>
            //    {
            //        new Movie {Name = "Movie1" },
            //        new Movie { Name = "Movie2"}
            //    };

            //    var viewModel = new RandomMovieViewModel
            //    {
            //        Movies = movies,
            //    };

            //    return View(viewModel);
            //}

            //public ActionResult Index()
            //{

            //    var movies = new List<Movie>
            //    {
            //        new Movie {Name = "Movie1" },
            //        new Movie { Name = "Movie2"}
            //    };

            //    var viewModel = new RandomMovieViewModel
            //    {
            //        Movies = movies,
            //    };

            //    return View(viewModel);
            //}

            //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
            //public ActionResult ByReleaseDate(int year, int month)
            //{
            //    return Content(year + "/" + month);
            //}
        }
}