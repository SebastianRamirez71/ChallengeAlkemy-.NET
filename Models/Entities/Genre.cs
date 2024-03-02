using System.Text.Json.Serialization;

namespace challange_disney.Models.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Movie>? Movies { get; set; } = new List<Movie>();
    }
}
