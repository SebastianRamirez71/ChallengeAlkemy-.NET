using System.ComponentModel.DataAnnotations;

namespace challange_disney.Models.Entities
{
    public class Movie
    {

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public int Rating { get; set; }
        [Range(1,5)]
        public int GenreId { get; set; }

        public IEnumerable<Character>? Characters { get; set; }



    }
}
