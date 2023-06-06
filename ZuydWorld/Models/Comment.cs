using System.ComponentModel.DataAnnotations;

namespace ZuydWorld.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public Game Game { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
