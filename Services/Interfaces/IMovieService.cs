﻿using challange_disney.DTO;
using challange_disney.Models.Entities;

namespace challange_disney.Services.Interfaces
{
    public interface IMovieService
    {
        Movie AddMovie(AddMovieDTO newMovie);
        List<Movie> GetMovies();
        void DeleteMovie(int id);
    }
}