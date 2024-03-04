using challange_disney.Models.Entities;
using AutoMapper;
using challange_disney.DTO;
using challange_disney.DTO.Movie;

namespace challange_disney.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Cuando las props de las 2 entidades tienen el mismo nombre, se realiza de esta manera
            //Character
           
            CreateMap<Character, CharacterDTO>();
            CreateMap<Character, CharacterWithDetailsDTO>();
        
            //Movie
            CreateMap<Movie, MovieDTO>();
            CreateMap<Movie, MovieWithDetailsDTO>();
        }
    }
}
