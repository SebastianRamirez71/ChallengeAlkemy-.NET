using challange_disney.Models.Entities;

namespace challange_disney.DTO
{
    public class CharacterWithDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public GeneralStatus Status { get; set; }
        public List<MovieDTO>? Movies { get; set; }

    }
}
