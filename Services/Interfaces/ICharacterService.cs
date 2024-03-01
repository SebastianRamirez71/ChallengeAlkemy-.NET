﻿using challange_disney.Data;
using challange_disney.DTO;
using challange_disney.Models.Entities;

namespace challange_disney.Services.Interfaces
{
    public interface ICharacterService
    {
        List<CharacterDTO> GetCharacters();
        Character AddCharacter(AddCharacterDTO newCharacter);
        Character UpdateCharacter(int id, UpdateCharacterDTO updateCharacterDTO);
        void DeleteCharacter(int id);
    }
}