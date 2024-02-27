using challange_disney.Models.Entities;
using AutoMapper;
using challange_disney.DTO;

namespace challange_disney.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Cuando tienen el mismo nombre de props se realiza de esta manera
            CreateMap<Movie, MovieDTO>(); 
        }
    }
}
