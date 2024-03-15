
using AutoMapper;
using challange_disney.Data;
using challange_disney.DTO;
using challange_disney.DTO.Movie;
using challange_disney.Mappings;
using challange_disney.Models.Entities;
using challange_disney.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public List<MovieWithDetailsDTO> GetMoviesByQuery(string? title, int? genre, string? orderBy)
        {
            var movies = _context.Movies
                .Where(x => x.Status == GeneralStatus.Activo).Include(c => c.Characters).ToList();
            if (title != null || genre != null || orderBy != null)
            {
                var byQuery = movies.Where(c =>
                    (title == null || c.Title.ToLower().Contains(title.ToLower())) &&
                    (!genre.HasValue || c.GenreId == genre)
                );

                if(orderBy != null)
                {
                    switch (orderBy.ToLower())
                    {
                        case "asc":
                            byQuery = byQuery.OrderBy(c => c.CreationDate);
                            break;
                        case "desc":
                            byQuery = byQuery.OrderByDescending(c => c.CreationDate);
                            break;
                        default:
                        
                            break;
                    }
                }

                return _mapper.Map<List<MovieWithDetailsDTO>>(byQuery);   

            }
            return _mapper.Map<List<MovieWithDetailsDTO>>(movies);
        }

        public List<T> GetMovies<T>()
        {
            IQueryable<Movie> MoviesQuery = _context.Movies
                .Where(x => x.Status == GeneralStatus.Activo);

            if (typeof(T) == typeof(MovieWithDetailsDTO)) // si el tipo es CharacterWithDetails se incluye las peliculas
            {
                MoviesQuery = MoviesQuery.Include(c => c.Characters);
            }

            var movies = _mapper.Map<List<T>>(MoviesQuery.ToList());

            return movies;
        }

        public Movie AddMovie(AddMovieDTO movieDTO)
        {
            var characters = _context.Characters.Where(c => movieDTO.CharacterId.Contains(c.Id)).ToList();
            if (characters.Count != movieDTO.CharacterId.Count)
            {
                var nonExistingCharacterIds = movieDTO.CharacterId.Except(characters.Select(c => c.Id));
                    throw new ArgumentException($"Los siguientes IDs de personajes no existen: {string.Join(",", nonExistingCharacterIds)}");
            }

            var genre = _context.Genres.SingleOrDefault(g => g.Id == movieDTO.GenreId);
            if (genre == null)
            {
                throw new ArgumentException($"El género con el ID: {movieDTO.GenreId} no existe");
            }


            var movie = new Movie
            {
                CreationDate = movieDTO.CreationDate,
                Image = movieDTO.Image,
                Title = movieDTO.Title,
                Rating = movieDTO.Rating,
                GenreId = genre.Id
            };

            foreach (var character in characters)
            {
                movie.Characters.Add(character);
            }

            // Agregar la película a la base de datos
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

        public Movie UpdateMovie(int id, UpdateMovieDTO movieDTO)
        {
            var movieToUpdate = _context.Movies.FirstOrDefault(x => x.Id == id);

            if (movieToUpdate != null)
            {

                movieToUpdate.CreationDate = movieDTO.CreationDate;
                movieToUpdate.Image = movieDTO.Image;
                movieToUpdate.Title = movieDTO.Title;
            }
            _context.SaveChanges();
            return movieToUpdate;
        }
    }
}
