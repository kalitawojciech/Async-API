using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public class MovieCollectionsController : ControllerBase
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly IMapper _mapper;
        public MovieCollectionsController(IMoviesRepository moviesRepository, IMapper mapper)
        {
            _moviesRepository = moviesRepository ?? throw new ArgumentNullException(nameof(moviesRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovieCollection([FromBody] IEnumerable<MovieForCreation> movieCollection)
        {
            var movieEntities = _mapper.Map<IEnumerable<Core.Entities.Movie>>(movieCollection);
            return Ok();
        }
    }
}
