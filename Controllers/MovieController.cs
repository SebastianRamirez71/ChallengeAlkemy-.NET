using AutoMapper;
using challange_disney.DTO;
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

        [HttpGet("Obtener")]
        public IActionResult GetMovies()
        {
            return Ok(_movieService.GetMovies());
        }

        [HttpPost]
        public IActionResult AddNewMovie([FromBody] AddMovieDTO movie)
        {
            var newMovie = _movieService.AddMovie(movie);
            return Ok(newMovie);
        }

        [HttpDelete("Eliminar")]
        public IActionResult DeleteMovie(int id)
        {
            _movieService.DeleteMovie(id);
            return Ok();
        }
        
    }
}
