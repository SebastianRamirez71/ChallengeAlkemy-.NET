using challange_disney.DTO;
using challange_disney.DTO.Character;
using challange_disney.DTO.Movie;
using challange_disney.Models.Entities;
using challange_disney.Services.Implementations;
using challange_disney.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Graph.Models;
using System.Threading.Tasks;

namespace challange_disney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : Controller
    {
       private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService service)
        {
            _characterService = service;
        }

        [HttpGet("/characters")]
        public IActionResult GetCharacters()
        {
            return Ok(_characterService.GetCharacters<CharacterDTO>());
        }

        [HttpGet("GetCharactersByQuery")]
        public IActionResult GetCharactersByQuery([FromQuery] string? name, int? age, int? movies)
        {
           return Ok(_characterService.GetCharactersByQuery(name, age, movies));
        }

        [HttpGet("GetCharacterWithDetails")]
        public IActionResult GetCharacterWithDetails()
        {
            return Ok(_characterService.GetCharacters<CharacterWithDetailsDTO>());
        }

        [HttpPost("AddCharacter")]
        public IActionResult AddCharacter([FromBody]AddCharacterDTO characterDTO)
        {
           var character = _characterService.AddCharacter(characterDTO);
           return StatusCode(StatusCodes.Status201Created, character);
        }

        [HttpPut("UpdateCharacter/{id}")]
        public IActionResult UpdateCharacter(int id, [FromBody] UpdateCharacterDTO updateCharacterDTO)
        {
            var characters = _characterService.GetCharacters<CharacterWithDetailsDTO>();
            var characterToCheck = characters.FirstOrDefault(x => x.Id == id);
            if (characterToCheck == null)
            {
                return NotFound($"El personaje con el ID: {id} no se ha encontrado");
            }
            _characterService.UpdateCharacter(id, updateCharacterDTO);
            return Ok();
        }

        [HttpDelete("RemoveCharacter/{id}")]
        public IActionResult DeleteCharacter(int id)
        {
            var characters = _characterService.GetCharacters<CharacterWithDetailsDTO>();
            var characterToCheck = characters.FirstOrDefault(x => x.Id == id);
            if (characterToCheck == null)
            {
                return NotFound($"El personaje con el ID: {id} no se ha encontrado");
            }
            _characterService.DeleteCharacter(id);
            return Ok();
        }
    }
}
