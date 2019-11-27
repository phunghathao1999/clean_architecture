using ApplicationCore.EF;
using ApplicationCore.Interfaces;

namespace Infrastructure.Persistence.Repositories
{
    public class PeopleRepository : EFRepository<People>, IPeopleRepository
    {
        public PeopleRepository(CinemaContext context) : base(context)
        {

        }

        protected new CinemaContext Context => base.Context as CinemaContext;
    }
}
