using challange_disney.DTO;
using challange_disney.Models.Entities;

namespace challange_disney.Services.Interfaces
{
    public interface IMovieService
    {
        Movie AddMovie(AddMovieDTO movieDTO);
        List<T> GetMovies<T>();
        Movie UpdateMovie(int id, UpdateMovieDTO movieDTO);
        void DeleteMovie(int id);
    }
}
