namespace DOTNET.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
        public byte[]? file { get; set; }
        public DateTime? Movie_Added { get; set; }

    }

}
