namespace ZuydWorld.Models
{
    public class Leaderboard
    {
        public Game Game { get; set; }
        public List<Score>? Scores { get; set; }
    }
}
