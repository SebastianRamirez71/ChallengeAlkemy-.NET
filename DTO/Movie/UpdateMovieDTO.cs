﻿using System.ComponentModel.DataAnnotations;

namespace challange_disney.DTO
{
    public class UpdateMovieDTO
    {
        public string Title { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public string Image { get; set; } = string.Empty;
        [Range(1, 5)]
        public int Rating { get; set; }
        public int GenreId { get; set; }
    }
}
