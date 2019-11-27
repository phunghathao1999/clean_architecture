using Microsoft.AspNetCore.Mvc.RazorPages;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ApplicationCore.DTO;

namespace RazorSample.Pages.Cinema
{
    public class IndexModel : PageModel
    {

        private readonly IMovieService _service;

        public IndexModel(IMovieService servie)
        {
            _service = servie;
        }

        //[BindProperty(SupportsGet = true)]
        //public string SearchString { get; set; }

        public PaginatedList<MovieDTO> Movies { get; set; }
        public PaginatedList<MovieDTO> Movie_trailer { get; set; }

        public void OnGet(string searchstring)
        {
            //ViewData["searchstring"] = searchstring;

            var movies = _service.GetMovies();
            var movie_trailer = _service.GetMovies();

            //if (!string.IsNullOrEmpty(searchstring))
            //{
            //    movies = movies.Where(m => m.Title.Contains(searchstring));
            //}
            var movietrailer = movie_trailer.Where(m => m.status.Contains("trailer")).OrderByDescending(m => m.MovieId).Take(5);
            Movie_trailer = new PaginatedList<MovieDTO>(movietrailer);

            movies = movies.OrderByDescending(m => m.MovieId).Take(5);
            Movies = new PaginatedList<MovieDTO>(movies);
        }
    }
}