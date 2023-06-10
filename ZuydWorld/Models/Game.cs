using System.ComponentModel.DataAnnotations;

namespace ZuydWorld.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string GameName { get; set; }
        public Category Category { get; set; }
        public Publisher Publisher { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
