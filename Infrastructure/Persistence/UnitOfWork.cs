using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CinemaContext _context;

        public UnitOfWork(CinemaContext context)
        {
            _context = context;
            Movies = new MovieRepository(context);
            People = new PeopleRepository(context);
        }

        public IMovieRepository Movies { get; }
        public IPeopleRepository People { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

    }
}