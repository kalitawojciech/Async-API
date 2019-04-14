using Microsoft.AspNetCore.Mvc;
using Movies.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Api.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMoviesRepository _moviesRepository;

        public MoviesController(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository ??
                throw new ArgumentNullException(nameof(moviesRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var moviesEntities = await _moviesRepository.GetMoviesAsync();
            return Ok(moviesEntities);
        }
    }
}
