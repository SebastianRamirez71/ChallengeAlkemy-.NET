using challange_disney.Models.Entities;
using AutoMapper;
using challange_disney.DTO;

namespace challange_disney.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Cuando las props de las 2 entidades tienen el mismo nombre, se realiza de esta manera
            CreateMap<Movie, MovieDTO>();
            CreateMap<Character, CharacterDTO>();
        }
    }
}
