using System.ComponentModel.DataAnnotations.Schema;

namespace DOTNET.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        
        
        public int membershiptype_id { get; set; }

        [ForeignKey("membershiptype_id")]
        public Membershiptype? Membershiptype { get; set; }
        public virtual ICollection<Movie>? Movie { get; set; }


    }
}
