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
        [HttpPost]
        public IActionResult AddCharacter(CharacterDTO characterDTO)
        {
            _characterService.AddCharacter(characterDTO);
            return Ok();
        }
    }
}
