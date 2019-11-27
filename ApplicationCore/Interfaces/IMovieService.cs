using ApplicationCore.DTO;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IMovieService
    {
        MovieDTO GetMovie(int id);

        IEnumerable<MovieDTO> GetMovies();
        IEnumerable<MovieDTO> GetMovies(int pageIndex, int pageSize, int count);

        int Count(string searchstring);

        void CreateMovie(MovieDTO movie);
        void UpdateMovie(MovieDTO movie);
        void DeleteMovie(int id);
    }
}
