namespace CDN.Domain.Entities
{
    public class Hobby
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Foreign key
        public int FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; } = null!;
    }
}
