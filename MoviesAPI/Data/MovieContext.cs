using MoviesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Data
{
    public class MovieContext(DbContextOptions<MovieContext> opts) : DbContext(opts)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>()
                .HasKey(x => new { x.Id, x.MovieTheaterId });

            modelBuilder.Entity<Session>()
                .HasOne(session => session.MovieTheater)
                .WithMany(movieTheater => movieTheater.Sessions)
                .HasForeignKey(session => session.MovieTheaterId);

            modelBuilder.Entity<Session>()
                .HasOne(session => session.Movie)
                .WithMany(movie => movie.Sessions)
                .HasForeignKey(session => session.MovieId);

            modelBuilder.Entity<Address>()
                .HasOne<MovieTheater>(address => address.MovieTheater)
                .WithOne(movieTheater => movieTheater.Address)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<MovieTheater> MovieTheaters { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Session> Sessions { get; set; }
    }
}
