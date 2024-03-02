using challange_disney.DTO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace challange_disney.Models.Entities
{

    public class Movie
    {
        public Movie()
        {
               Status = GeneralStatus.Activo;
        }
        public int Id { get; set; }
        [Required(ErrorMessage ="Titulo de la pelicula requerido")]
        public string Title { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        [Required(ErrorMessage = "Fecha de publicacion requerido")]
        public DateTime CreationDate { get; set; }
        [Required(ErrorMessage = "Puntuacion requerida")]
        [Range(1, 5)]
        public int Rating { get; set; }
        public int GenreId { get; set; }
        public GeneralStatus Status { get; set; }
        [JsonIgnore]
        public ICollection<Character>? Characters { get; set; } = new List<Character>();
    }
}
