using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Filters;
using Movies.Core.Interfaces;
using Movies.Core.Models;
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
        private readonly IMapper _mapper;

        public MoviesController(IMoviesRepository moviesRepository, IMapper mapper)
        {
            _moviesRepository = moviesRepository ??
                throw new ArgumentNullException(nameof(moviesRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [MoviesResultFilter]
        public async Task<IActionResult> GetMovies()
        {
            var moviesEntities = await _moviesRepository.GetMoviesAsync();
            return Ok(moviesEntities);
        }

        [HttpGet]
        [MovieResultFilter]
        [Route("{id}")]
        public async Task<IActionResult> GetMovie(Guid movieId)
        {
            var movieEntity = await _moviesRepository.GetMovieAsync(movieId);
            if(movieEntity == null)
            {
                return NotFound();
            }
            return Ok(movieEntity);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] MovieForCreation movie)
        {
            var movieEntity = _mapper.Map<Core.Entities.Movie>(movie);
            _moviesRepository.AddMovie(movieEntity);

            await _moviesRepository.SaveChangesAsync();
            return Ok();
        }
    }
}
