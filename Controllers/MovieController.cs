using AutoMapper;
using challange_disney.DTO;
using challange_disney.DTO.Movie;
using challange_disney.Models.Entities;
using challange_disney.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace challange_disney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
  
        public MovieController(IMovieService service)
        {
            _movieService = service;
            
        }

        [HttpGet("Movies")]
        public IActionResult GetMovies()
        {
            return Ok(_movieService.GetMovies<MovieDTO>());
        }

        [HttpGet("MoviesByQuery")]
        public IActionResult GetMoviesByQuery(string? title, int? genre, string? orderBy)
        {
            return Ok(_movieService.GetMoviesByQuery(title, genre, orderBy));
        }
        
        [HttpGet("MoviesWithDetails")]
        public IActionResult GetMoviesWithDetails()
        {
            return Ok(_movieService.GetMovies<MovieWithDetailsDTO>());
        }

        [HttpPost("AddMovie")]
        public IActionResult AddMovie([FromBody] AddMovieDTO movie)
        {
            var newMovie = _movieService.AddMovie(movie);
            return StatusCode(StatusCodes.Status201Created, newMovie);
        }

        [HttpPut("UpdateMovie/{id}")]
        public IActionResult UpdateMovie(int id, [FromBody]UpdateMovieDTO movieDTO)
        {
            var movies = _movieService.GetMovies<MovieWithDetailsDTO>();
            var characterToCheck = movies.FirstOrDefault(x => x.Id == id);
            if(characterToCheck == null)
            {
                return NotFound($"La pelicula con el ID: {id} no se ha encontrado");
            }
           _movieService.UpdateMovie(id, movieDTO);
            return Ok();
        }

        [HttpDelete("RemoveMovie/{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movies = _movieService.GetMovies<MovieWithDetailsDTO>();
            var characterToCheck = movies.FirstOrDefault(x => x.Id == id);
            if (characterToCheck == null)
            {
                return NotFound($"La pelicula con el ID: {id} no se ha encontrado");
            }
            _movieService.DeleteMovie(id);
            return Ok();
        }
        
    }
}
