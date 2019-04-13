using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Infrastructure.Contexts
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Director>().HasData(
                new Director()
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    FirstName = "James",
                    LastName = "Cameron"
                },
                new Director()
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                    FirstName = "Steven",
                    LastName = "Spielberg"
                }
                );
            modelBuilder.Entity<Movie>().HasData(
                new Movie()
                {
                    Id = Guid.Parse("21111111-1111-1111-1111-111111111111"),
                    DirectorId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Title = "Avatar",
                    Description = "Avatar's description."
                },
                new Movie()
                {
                    Id = Guid.Parse("21111111-1111-1111-1111-111111111112"),
                    DirectorId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                    Title = "Jurassic Park",
                    Description = "Jurassic Park's description."
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
