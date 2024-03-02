using challange_disney.DTO.Genre;
using challange_disney.Models.Entities;

namespace challange_disney.Services.Interfaces
{
    public interface IGenreService
    {
        List<Genre> GetGenres();
        Genre AddGenre(AddGenreDTO newGenre);
    }
}
