using AutoMapper;
using challange_disney.DTO;
using challange_disney.DTO.Movie;
using challange_disney.Models.Entities;
using challange_disney.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace challange_disney.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
  
        public MovieController(IMovieService service)
        {
            _movieService = service;
            
        }

        [HttpGet("movies")]
        public IActionResult GetMovies()
        {
            return Ok(_movieService.GetMovies<MovieDTO>());
        }
        [HttpGet("MoviesWDetails")]
        public IActionResult GetMoviesWithDetails()
        {
            return Ok(_movieService.GetMovies<MovieWithDetailsDTO>());
        }

        [HttpPost("AddMovie")]
        public IActionResult AddMovie([FromBody] AddMovieDTO movie)
        {
            var newMovie = _movieService.AddMovie(movie);
            return Ok(newMovie);
        }

        [HttpPut("UpdateMovie/{id}")]
        public IActionResult UpdateMovie(int id, [FromBody]UpdateMovieDTO movieDTO)
        {
           var updateMovie = _movieService.UpdateMovie(id, movieDTO);
            return Ok(updateMovie);
        }

        [HttpDelete("RemoveMovie/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            _movieService.DeleteMovie(id);
            return Ok();
        }
        
    }
}
