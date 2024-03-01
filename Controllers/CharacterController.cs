using challange_disney.DTO;
using challange_disney.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace challange_disney.Controllers
{
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
            return Ok(_characterService.GetCharacters());
        }
        [HttpPost("AddCharacter")]
        public IActionResult AddCharacter(AddCharacterDTO characterDTO)
        {
            _characterService.AddCharacter(characterDTO);
            return Ok();
        }

        [HttpPut("UpdateCharacter/{id}")]
        public IActionResult UpdateCharacter(int id, [FromBody]UpdateCharacterDTO updateCharacterDTO)
        {
            _characterService.UpdateCharacter(id, updateCharacterDTO);
            return Ok();
        }

        [HttpDelete("RemoveCharacter")]
        public IActionResult DeleteCharacter(int id)
        {
            _characterService.DeleteCharacter(id);
            return Ok();
        }
    }
}
