using Infrastructure.Persistence;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(CinemaContext context)
        {
            context.Database.EnsureCreated();

            if (context.Movie.Any()) return;

            if (context.People.Any()) return;
            
            if (context.SeatReserved.Any()) return;
            
            if (context.Seat.Any()) return;
            
            if (context.Screening.Any()) return;
            
            if (context.Reservation.Any()) return;

            context.SaveChanges();
        }
    }
}