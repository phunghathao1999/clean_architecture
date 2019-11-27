using System.Collections.Generic;
using System.Linq;
using ApplicationCore.DTO;
using ApplicationCore.EF;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MovieService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public MovieDTO GetMovie(int id)
        {
            var movie = _unitOfWork.Movies.GetBy(id);
            return _mapper.Map<Movie, MovieDTO>(movie);
        }

        public IEnumerable<MovieDTO> GetMovies()
        {
            var movies = _unitOfWork.Movies.GetAll();
            return _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(movies);
        }

        public IEnumerable<MovieDTO> GetMovies(int pageIndex, int pageSize,int count)
        {
            //count = _unitOfWork.Movies.GetAll().Count();
            var movieSpecPaging = new MovieSpecification(pageIndex, pageSize);

            var movies = _unitOfWork.Movies.Find(movieSpecPaging);
            return _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(movies);
        }

        public void CreateMovie(MovieDTO moviedto)
        {
            var movie = _mapper.Map<MovieDTO,Movie>(moviedto);
            _unitOfWork.Movies.Add(movie);
        }

        public void DeleteMovie(int id)
        {
            var movie = _unitOfWork.Movies.GetBy(id);

            if (movie == null) return;

            _unitOfWork.Movies.Remove(movie);

            _unitOfWork.Complete();
        }

        public void UpdateMovie(MovieDTO moviedto)
        {
            throw new System.NotImplementedException();
        }

        public int Count(string searchstring)
        {
            var movies = _unitOfWork.Movies.GetAll();
            movies = movies.Where(m => m.Title.Contains(searchstring));
            return movies.Count();
        }
    }
}
