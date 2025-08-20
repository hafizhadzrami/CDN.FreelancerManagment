using CDN.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CDN.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Skillset> Skillsets { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-many: Freelancer -> Skillsets
            modelBuilder.Entity<Skillset>()
                .HasOne(s => s.Freelancer)
                .WithMany(f => f.Skillsets)
                .HasForeignKey(s => s.FreelancerId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-many: Freelancer -> Hobbies
            modelBuilder.Entity<Hobby>()
                .HasOne(h => h.Freelancer)
                .WithMany(f => f.Hobbies)
                .HasForeignKey(h => h.FreelancerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
