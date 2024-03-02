using AutoMapper;
using challange_disney.Data;
using challange_disney.DTO;
using challange_disney.DTO.Character;
using challange_disney.Mappings;
using challange_disney.Models.Entities;
using challange_disney.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        public List<T> GetCharacters<T>()
        {
            IQueryable<Character> charactersQuery = _context.Characters
                .Where(x => x.Status == GeneralStatus.Activo);

            if (typeof(T) == typeof(CharacterWithDetailsDTO)) // si el tipo es CharacterWithDetails se incluye las peliculas
            {
                charactersQuery = charactersQuery.Include(c => c.Movies);  
            }

            var characters = _mapper.Map<List<T>>(charactersQuery.ToList());

            return characters;
        }

        public Character AddCharacter(AddCharacterDTO newCharacter)
        {
            var character = new Character
            {
                Image = newCharacter.Image,
                Name = newCharacter.Name,
                Age = newCharacter.Age,
                Bio = newCharacter.Bio,
                Weight = newCharacter.Weight
            };

            foreach (var movieId in newCharacter.MovieId)
            {
                var existingMovieId = _context.Movies.FirstOrDefault(m => m.Id == movieId);
                if (existingMovieId != null)
                {
                    character.Movies.Add(existingMovieId);
                }
                else
                {
                    throw new ArgumentException($"La pelicula con el  ID: {movieId} no existe");
                }
            }

            _context.Characters.Add(character);
            _context.SaveChanges();
            return character;
        }
        public Character UpdateCharacter(int id, UpdateCharacterDTO updateCharacterDTO)
        {
            var updateCharacter = _context.Characters.FirstOrDefault(x => x.Id == id);
            if(updateCharacter != null)
            {
                updateCharacter.Name = updateCharacterDTO.Name;
                updateCharacter.Age = updateCharacterDTO.Age;
                updateCharacter.Bio = updateCharacterDTO.Bio;
                updateCharacter.Weight = updateCharacterDTO.Weight;
            }
            _context.SaveChanges();
            return updateCharacter;
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
