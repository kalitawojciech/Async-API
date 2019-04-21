using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;
using Movies.Core.Interfaces;
using Movies.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Services
{
    public class MoviesRepository : IMoviesRepository, IDisposable
    {
        private MoviesContext _context;

        public MoviesRepository(MoviesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Movie> GetMovieAsync(Guid Id)
        {
            return await _context.Movies.Include(m => m.Director).FirstOrDefaultAsync(m => m.Id == Id);
        }

        public async Task<IEnumerable<Core.Entities.Movie>> GetMoviesAsync()
        {
            return await _context.Movies.Include(m => m.Director).ToListAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public void AddMovie(Movie movieToAdd)
        {
            if(movieToAdd == null)
            {
                throw new ArgumentNullException(nameof(movieToAdd));
            }

            _context.Add(movieToAdd);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<IEnumerable<Core.Entities.Movie>> GetMoviesAsync(IEnumerable<Guid> moviesIds)
        {
            return await _context.Movies.Where(m => moviesIds.Contains(m.Id))
                .Include(m => m.Director).ToListAsync();
        }
    }
}
