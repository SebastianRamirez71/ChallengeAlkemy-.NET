using System.ComponentModel.DataAnnotations;

namespace challange_disney.DTO
{
    public class AddMovieDTO
    {
        public string Title { get; set; } = string.Empty;
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreationDate { get; set; }
        public string Image { get; set; } = string.Empty;
        [Range(1, 5)]
        public int Rating { get; set; }
        public int GenreId { get; set; }
        public List<int> CharacterId { get; set; }

    }
}
