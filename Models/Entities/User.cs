using challange_disney.DTO;

namespace challange_disney.Models
{
    public class User
    {
        public User()
        {
            Status = GeneralStatus.Activo; 
        }
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public GeneralStatus Status { get; set; }
    }
}
