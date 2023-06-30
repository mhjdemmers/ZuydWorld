using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace ZuydWorld.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Game>? Likes { get; set; }
        //public List<Game>? Favorites { get; set; }
        public bool Moderator { get; set; }
        public bool Banned { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
