using challange_disney.DTO.Genre;
using challange_disney.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace challange_disney.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService service)
        {
            _genreService = service;
        }

        [HttpGet("Genres")]
        public IActionResult GetGenres()
        {
            return Ok(_genreService.GetGenres());
        }
        [HttpPost("Add")]
        public IActionResult AddGenre([FromBody]AddGenreDTO newGenre)
        {
            return Ok(_genreService.AddGenre(newGenre));
        }
    }
}
