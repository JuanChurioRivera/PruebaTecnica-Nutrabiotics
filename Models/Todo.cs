
namespace PruebaTenicaTodos.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string title { get; set; }
        public DateTime created_date { get; set; }
        public DateTime? completed_date { get; set; }
        public string description { get; set; }
        public bool state { get; set; }
        public int priority { get; set; }
        public User? user { get; set; }

    }
}
