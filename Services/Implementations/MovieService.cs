
using AutoMapper;
using challange_disney.Data;
using challange_disney.DTO;
using challange_disney.Mappings;
using challange_disney.Models.Entities;
using challange_disney.Services.Interfaces;

namespace challange_disney.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public MovieService(Context context)
        {
            _context = context;
            _mapper = AutoMapperConfig.Configure();
           
            
        }
        public List<MovieDTO> GetMovies()
        {
            return _mapper.Map<List<MovieDTO>>(_context.Movies.Where(x => x.Status == GeneralStatus.Activo)).ToList();
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
                movieToDelete.Status = GeneralStatus.Inactivo;
                _context.SaveChanges();
            }
        }

        
    }
}
