using challange_disney.Data;
using challange_disney.DTO;
using challange_disney.Models.Entities;
using challange_disney.Services.Interfaces;

namespace challange_disney.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly Context _context;
        public MovieService(Context context)
        {
            _context = context;
        }
        public List<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie AddMovie(AddMovieDTO newMovie)
        {
            var movie = new Movie
            {
                CreationDate = newMovie.CreationDate,
                Image = newMovie.Image,
                Title = newMovie.Title,
                Rating = newMovie.Rating,
                GenreId = newMovie.GenreId,
            };
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
            

        }

        public void DeleteMovie(int id)
        {
            var movieToDelete = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movieToDelete != null)
            {
                movieToDelete.Status = MovieStatus.Inactivo;
                _context.SaveChanges();
            }
        }

        
    }
}
