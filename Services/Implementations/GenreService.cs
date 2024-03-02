using AutoMapper;
using challange_disney.Data;
using challange_disney.DTO.Genre;
using challange_disney.Mappings;
using challange_disney.Models.Entities;
using challange_disney.Services.Interfaces;

namespace challange_disney.Services.Implementations
{
    public class GenreService : IGenreService
    {
        private readonly IMapper _mapper;
        private readonly Context _context;
        public GenreService(Context context)
        {
            _context = context;
            _mapper = AutoMapperConfig.Configure();
        }

        public Genre AddGenre(AddGenreDTO newGenre)
        {
            var genre = new Genre
            {
                Image = newGenre.Image,
                Name = newGenre.Name,
            };

            foreach (var movieId in newGenre.MovieId)
            {
                var existingMovieId = _context.Movies.FirstOrDefault(m => m.Id == movieId);
                if (existingMovieId != null)
                {
                    genre.Movies.Add(existingMovieId);
                }
                else
                {
                    throw new ArgumentException($"La pelicula con el  ID: {movieId} no existe");
                }
            }
            _context.Genres.Add(genre);
            _context.SaveChanges();
            return genre;
           
        }

        public List<Genre> GetGenres()
        {
            return _mapper.Map<List<Genre>>(_context.Genres.ToList());
        }
    }
}
