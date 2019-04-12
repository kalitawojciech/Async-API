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

        DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Director>().HasData(
                new Director()
                {
                    Id = Guid.Parse("1"),
                    FirstName = "James",
                    LastName = "Cameron"
                },
                new Director()
                {
                    Id = Guid.Parse("2"),
                    FirstName = "Steven",
                    LastName = "Spielberg"
                }
                );
            modelBuilder.Entity<Movie>().HasData(
                new Movie()
                {
                    Id = Guid.Parse("1"),
                    DirectorId = Guid.Parse("1"),
                    Title = "Avatar",
                    Description = "Avatar's description."
                },
                new Movie()
                {
                    Id = Guid.Parse("2"),
                    DirectorId = Guid.Parse("2"),
                    Title = "Jurassic Park",
                    Description = "Jurassic Park's description."
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
