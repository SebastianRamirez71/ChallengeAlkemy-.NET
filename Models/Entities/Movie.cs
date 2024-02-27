﻿using challange_disney.DTO;
using System.ComponentModel.DataAnnotations;

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
        public int Rating { get; set; }
        [Range(1,5)]
        public int GenreId { get; set; }
        public GeneralStatus Status { get; set; }

        public IEnumerable<Character>? Characters { get; set; }



    }
}
