using System.ComponentModel.DataAnnotations;

namespace ZuydWorld.Models
{
    public class Leaderboard
    {
        [Key]
        public Game Game { get; set; }
        public List<Score>? Scores { get; set; }
    }
}
