namespace challange_disney.DTO.Character
{
    public class AddCharacterDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Weight { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public List<int> MovieId { get; set; }
    }
}
