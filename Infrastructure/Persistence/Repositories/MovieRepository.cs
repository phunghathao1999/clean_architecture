using ApplicationCore.Interfaces;
using ApplicationCore.EF;

namespace Infrastructure.Persistence.Repositories
{
    public class MovieRepository : EFRepository<Movie>, IMovieRepository
    {
        public MovieRepository(CinemaContext context) : base(context)
        {

        }

        protected new CinemaContext Context => base.Context as CinemaContext;

    }
}
