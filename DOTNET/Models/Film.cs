namespace TP4.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public IEnumerable<Role>? Roles { get; set; }

        
    }
}
