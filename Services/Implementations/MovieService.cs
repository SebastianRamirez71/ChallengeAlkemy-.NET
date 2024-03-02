﻿
using AutoMapper;
using challange_disney.Data;
using challange_disney.DTO;
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


        public List<T> GetMovies<T>()
        {
            IQueryable<Movie> MoviesQuery = _context.Movies
                .Where(x => x.Status == GeneralStatus.Activo);

            if (typeof(T) == typeof(CharacterWithDetailsDTO)) // si el tipo es CharacterWithDetails se incluye las peliculas
            {
                MoviesQuery = MoviesQuery.Include(c => c.Characters);
            }

            var movies = _mapper.Map<List<T>>(MoviesQuery.ToList());

            return movies;
        }

        public Movie AddMovie(AddMovieDTO movieDTO)
        {
            var movie = new Movie
            {
                CreationDate = movieDTO.CreationDate,
                Image = movieDTO.Image,
                Title = movieDTO.Title,
                GenreId = movieDTO.GenreId,
                Rating = movieDTO.Rating
            };

            foreach (var characterId in movieDTO.CharacterId)
            {
                var existingCharacterId = _context.Characters.FirstOrDefault(c => c.Id == characterId);
                if (existingCharacterId != null)
                {
                    movie.Characters.Add(existingCharacterId);
                }
                else
                {
                    throw new ArgumentException($"El personaje con el ID: {characterId} no existe");
                }
            }


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
