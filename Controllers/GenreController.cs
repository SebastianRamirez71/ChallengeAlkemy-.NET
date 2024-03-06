using challange_disney.DTO.Genre;
using challange_disney.Models;
using challange_disney.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace challange_disney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenreController : Controller
    {
        
        private readonly IGenreService _genreService;
        private readonly IAuthService _authService;
        public GenreController(IGenreService service, IAuthService authService)
        {
            _genreService = service;
            _authService = authService;

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
