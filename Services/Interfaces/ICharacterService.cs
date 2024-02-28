using challange_disney.Data;
using challange_disney.DTO;
using challange_disney.Models.Entities;

namespace challange_disney.Services.Interfaces
{
    public interface ICharacterService
    {
        List<CharacterDTO> GetCharacters();
        Character AddCharacter(CharacterDTO newCharacter);
        void DeleteCharacter(int id);
    }
}
