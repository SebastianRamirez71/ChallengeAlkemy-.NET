namespace challange_disney.DTO.Genre
{
    public class AddGenreDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public List<int> MovieId { get; set; }
    }
}
