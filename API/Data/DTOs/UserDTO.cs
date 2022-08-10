using API.Entities;

namespace API.Data.DTOs
{
    public class UserDTO
    {
        public string Password { get; set; }

        public int? Id { get; set; }

        public string Name { get; set; }
        
        public bool Deleted { get; set; }

        public UserDTO (User user)
        {
            Password = user.Password;
            Id = user.Id;
            Name = user.Name;
            Deleted = user.Deleted;
        }
    }
}