namespace ZuydWorld.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public Leaderboard? Scoreboard { get; set; }
        public Category Category { get; set; }
        public Publisher Publisher { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
