using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Api
{
    public class MoviesProfile : Profile
    {
        public MoviesProfile()
        {
            CreateMap<Core.Entities.Movie, Core.Models.Movie>().ForMember(dest => dest.Director, opt => opt.MapFrom(src =>
                $"{src.Director.FirstName} {src.Director.LastName}"));

            CreateMap<Core.Models.MovieForCreation, Core.Models.Movie>();
        }
    }
}
