using System.ComponentModel.DataAnnotations;

namespace challange_disney.DTO.Movie
{
    public class MovieWithDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public int Rating { get; set; }
        public int GenreId { get; set; }
        public GeneralStatus Status { get; set; }
        public List<CharacterDTO> Characters { get; set; }  
    }
}
