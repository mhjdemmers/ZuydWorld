namespace ZuydWorld.Models
{
    public class Score
    {
        public User User {  get; set; }
        public Game Game { get; set; }
        public int Highscore { get; set; }
        public DateTime Date { get; set; }
    }
}
