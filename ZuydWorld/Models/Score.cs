using System.ComponentModel.DataAnnotations;

namespace ZuydWorld.Models
{
    public class Score
    {
        [Key]
        public User User {  get; set; }
        public Game Game { get; set; }
        public int Highscore { get; set; }
        public DateTime Date { get; set; }
    }
}
