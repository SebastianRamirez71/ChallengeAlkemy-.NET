using challange_disney.Data;
using challange_disney.DTO;
using challange_disney.DTO.Character;
using challange_disney.Models.Entities;

namespace challange_disney.Services.Interfaces
{
    public interface ICharacterService
    {
        List<CharacterWithDetailsDTO> GetCharactersByQuery(string? name, int? age, int? movies);
        List<T> GetCharacters<T>();
        Character AddCharacter(AddCharacterDTO newCharacter);
        Character UpdateCharacter(int id, UpdateCharacterDTO updateCharacterDTO);
        void DeleteCharacter(int id);
    }
}
