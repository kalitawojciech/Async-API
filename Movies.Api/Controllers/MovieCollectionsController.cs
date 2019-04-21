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
    [Route("api/moviecollections")]
    [ApiController]
    [MoviesResultFilter]
    public class MovieCollectionsController : ControllerBase
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly IMapper _mapper;
        public MovieCollectionsController(IMoviesRepository moviesRepository, IMapper mapper)
        {
            _moviesRepository = moviesRepository ?? throw new ArgumentNullException(nameof(moviesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("({movieIds})", Name = "GetMovieCollection")]
        public async Task<IActionResult> GetMovieCollection(
            [ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> movieIds)
        {
            var movieEntities = await _moviesRepository.GetMoviesAsync(movieIds);
            if(movieEntities.Count() != movieIds.Count())
            {
                return NotFound();
            }

            return Ok(movieEntities);
        }


        [HttpPost]
        public async Task<IActionResult> CreateMovieCollection([FromBody] IEnumerable<MovieForCreation> movieCollection)
        {
            var movieEntities = _mapper.Map<IEnumerable<Core.Entities.Movie>>(movieCollection);
            foreach(var movieEntity in movieEntities)
            {
                _moviesRepository.AddMovie(movieEntity);
            }

            await _moviesRepository.SaveChangesAsync();

            var moviesToReturn = await _moviesRepository.GetMoviesAsync(
                                    movieEntities.Select(m => m.Id).ToList());

            var movieIds = string.Join(",", moviesToReturn.Select(a => a.Id));
            return CreatedAtRoute("GetMovieCollection",
                new { movieIds },
                moviesToReturn);
        }
    }
}
