using System.ComponentModel.DataAnnotations;

namespace ZuydWorld.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        public string PublisherName { get; set; }
    }
}
