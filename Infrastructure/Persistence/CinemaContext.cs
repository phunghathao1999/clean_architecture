using ApplicationCore.EF;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public partial class CinemaContext : DbContext
    {
        public CinemaContext()
        {
        }

        public CinemaContext(DbContextOptions<CinemaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Screening> Screening { get; set; }
        public virtual DbSet<Seat> Seat { get; set; }
        public virtual DbSet<SeatReserved> SeatReserved { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=admin\\sqlthao;Database=Cinema;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.Actor)
                    .HasColumnName("actor")
                    .HasMaxLength(1024);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Director)
                    .HasColumnName("director")
                    .HasMaxLength(255);

                entity.Property(e => e.DurationMin).HasColumnName("duration_min");

                entity.Property(e => e.FilmStudios)
                    .HasColumnName("film_studios")
                    .HasMaxLength(255);

                entity.Property(e => e.Img1)
                    .HasColumnName("img1")
                    .HasMaxLength(255);

                entity.Property(e => e.Img2)
                    .HasColumnName("img2")
                    .HasMaxLength(255);

                entity.Property(e => e.Released)
                    .HasColumnName("released")
                    .HasColumnType("date");

                entity.Property(e => e.Scores).HasColumnName("scores");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255);

                entity.Property(e => e.Title1)
                    .HasColumnName("title1")
                    .HasMaxLength(255);

                entity.Property(e => e.Trailer)
                    .HasColumnName("trailer")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<People>(entity =>
            {
                entity.Property(e => e.PeopleId).HasColumnName("people_id");

                entity.Property(e => e.Account)
                    .HasColumnName("account")
                    .HasMaxLength(50);

                entity.Property(e => e.Addre)
                    .HasColumnName("addre")
                    .HasMaxLength(255);

                entity.Property(e => e.Born)
                    .HasColumnName("born")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Pass)
                    .HasColumnName("pass")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.ReservationId).HasColumnName("reservation_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Paid).HasColumnName("paid");

                entity.Property(e => e.PeopleId).HasColumnName("people_id");

                entity.Property(e => e.ReservationContact)
                    .HasColumnName("reservation_contact")
                    .HasMaxLength(1024);

                entity.Property(e => e.ReservationTypeId).HasColumnName("reservation_type_id");

                entity.Property(e => e.ScreeningId).HasColumnName("screening_id");

                entity.HasOne(d => d.People)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.PeopleId)
                    .HasConstraintName("FK__Reservati__peopl__25869641");

                entity.HasOne(d => d.Screening)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.ScreeningId)
                    .HasConstraintName("FK__Reservati__scree__24927208");
            });

            modelBuilder.Entity<Screening>(entity =>
            {
                entity.Property(e => e.ScreeningId).HasColumnName("screening_id");

                entity.Property(e => e.AuditoriumId).HasColumnName("auditorium_id");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.ScreeningStart)
                    .HasColumnName("screening_start")
                    .HasColumnType("datetime");

                //entity.HasOne(d => d.Movie)
                //    .WithMany(p => p.Screening)
                //    .HasForeignKey(d => d.MovieId)
                //    .HasConstraintName("FK__Screening__movie__164452B1");
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.Property(e => e.SeatId).HasColumnName("seat_id");

                entity.Property(e => e.AuditoriumId).HasColumnName("auditorium_id");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.Row)
                    .HasColumnName("row")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SeatReserved>(entity =>
            {
                entity.ToTable("Seat_reserved");

                entity.Property(e => e.SeatReservedId).HasColumnName("seat_reserved_id");

                entity.Property(e => e.ReservationId).HasColumnName("reservation_id");

                entity.Property(e => e.ScreeningId).HasColumnName("screening_id");

                entity.Property(e => e.SeatId).HasColumnName("seat_id");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.SeatReserved)
                    .HasForeignKey(d => d.ReservationId)
                    .HasConstraintName("FK__Seat_rese__reser__286302EC");

                entity.HasOne(d => d.Screening)
                    .WithMany(p => p.SeatReserved)
                    .HasForeignKey(d => d.ScreeningId)
                    .HasConstraintName("FK__Seat_rese__scree__1FCDBCEB");

                entity.HasOne(d => d.Seat)
                    .WithMany(p => p.SeatReserved)
                    .HasForeignKey(d => d.SeatId)
                    .HasConstraintName("FK__Seat_rese__seat___1ED998B2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
