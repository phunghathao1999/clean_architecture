using ApplicationCore.DTO;
using ApplicationCore.EF;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapper Movie
            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieDTO, Movie>();

            // Mapper People
            CreateMap<People,PeopleDTO>();
            CreateMap<PeopleDTO,People>();
            CreateMap<People, LoginDTO>();
        }
    }
}
