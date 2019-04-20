using Microsoft.AspNetCore.Mvc;
using Movies.Core.Interfaces;
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
        public MovieCollectionsController(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
    }
}
