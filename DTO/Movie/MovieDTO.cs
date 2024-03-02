using System.ComponentModel.DataAnnotations;

namespace challange_disney.DTO
{

    public class MovieDTO
    {

        public string Image { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        

    }
}
