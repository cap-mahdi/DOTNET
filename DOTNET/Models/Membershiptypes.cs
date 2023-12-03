namespace TP3.Models
{
    public class Membershiptype
    {
        public int Id { get; set; }
        public double SignUpFee { get; set; }

        public int DurationInMonth { get; set; }

        public double DiscountRate { get; set; }

        public virtual ICollection<Customer>? Customer { get; set; }
    }
}
