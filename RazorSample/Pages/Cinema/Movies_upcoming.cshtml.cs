using ApplicationCore.DTO;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace RazorSample.Pages.Cinema
{
    public class Movies_in_weekModel : PageModel
    {
        private int pageSize = 6;

        private readonly IMovieService _service;

        public Movies_in_weekModel(IMovieService servie)
        {
            _service = servie;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public PaginatedList<MovieDTO> Movies { get; set; }

        public PaginatedList<MovieDTO> Movie_trailer { get; set; }

        public void OnGet(string searchstring, int pageIndex = 1)
        {
            ViewData["searchstring"] = searchstring;

            int count = _service.GetMovies().Where(m => m.status.Contains("trailer")).Count();

            var movies = _service.GetMovies(pageIndex, pageSize, count).Where(m => m.status.Contains("trailer"));
            var movie_trailer = _service.GetMovies().Where(m => m.status.Contains("trailer"));

            if (!string.IsNullOrEmpty(searchstring))
            {
                movies = movies.Where(m => m.Title.Contains(searchstring));
                count = _service.GetMovies().Where(m => m.Title.Contains(searchstring) && m.status.Contains("trailer")).Count();
            }
            var movietrailer = movie_trailer.Where(m => m.status.Contains("trailer")).OrderByDescending(m => m.MovieId).Take(5);
            Movie_trailer = new PaginatedList<MovieDTO>(movietrailer);

            movies = movies.OrderByDescending(m => m.MovieId);
            Movies = new PaginatedList<MovieDTO>(movies, pageIndex, pageSize, count);
        }
    }
}