﻿using Movies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Interfaces
{
    public interface IMoviesRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieAsync(Guid Id);
        Task<IEnumerable<Core.Entities.Movie>> GetMoviesAsync(IEnumerable<Guid> moviesIds);
        void AddMovie(Entities.Movie movieToAdd);

        Task<bool> SaveChangesAsync();
    }
}
