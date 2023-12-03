namespace DOTNET.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Movie>? Movie { get; set; }
    }
}
