using API.Data.DTOs;

namespace API.Entities
{
    public class User : Entity
    {
        public string Password { get; set; }

        public User() { }
        
        public User(UserDTO user)
        {
            Id = user.Id ?? (int)user.Id;
            Name = user.Name;
            Password = user.Password;
        }
    }
}