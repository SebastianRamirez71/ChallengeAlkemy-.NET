namespace challange_disney.Models.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public IEnumerable<Movie>? Movies { get; set; }

    }
}
