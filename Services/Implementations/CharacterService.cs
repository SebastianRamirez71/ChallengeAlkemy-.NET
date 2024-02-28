using AutoMapper;
using challange_disney.Data;
using challange_disney.DTO;
using challange_disney.Mappings;
using challange_disney.Models.Entities;
using challange_disney.Services.Interfaces;

namespace challange_disney.Services.Implementations
{
    public class CharacterService : ICharacterService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public CharacterService(Context context)
        {
            _context = context;
            _mapper = AutoMapperConfig.Configure();
        }
        public List<CharacterDTO> GetCharacters()
        {
            return _mapper.Map<List<CharacterDTO>>(_context.Characters.Where(x => x.Status == GeneralStatus.Activo)).ToList();
        }
        public Character AddCharacter(CharacterDTO newCharacter)
        {
            var character = new Character
            {
                Image = newCharacter.Image,
                Name = newCharacter.Name,
                
                
            };
            _context.Characters.Add(character);
            _context.SaveChanges();
            return character;
        }

        public void DeleteCharacter(int id)
        {
            var CharacterToDelete = _context.Characters.FirstOrDefault(x => x.Id == id);
            if (CharacterToDelete != null)
            {
                CharacterToDelete.Status = GeneralStatus.Inactivo;
                _context.SaveChanges();
            }
        }

       
    }
}
