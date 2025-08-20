using CDN.Application.Interfaces;
using CDN.Domain.Entities;
using CDN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CDN.Infrastructure.Repositories
{
    public class FreelancerRepository : IFreelancerRepository
    {
        private readonly AppDbContext _context;

        public FreelancerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Freelancer>> GetAllAsync()
        {
            return await _context.Freelancers
                .Include(f => f.Skillsets)
                .Include(f => f.Hobbies)
                .ToListAsync();
        }

        public async Task<Freelancer?> GetByIdAsync(int id)
        {
            return await _context.Freelancers
                .Include(f => f.Skillsets)
                .Include(f => f.Hobbies)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddAsync(Freelancer freelancer)
        {
            _context.Freelancers.Add(freelancer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Freelancer freelancer)
        {
            _context.Freelancers.Update(freelancer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Freelancer freelancer)
        {
            _context.Freelancers.Remove(freelancer);
            await _context.SaveChangesAsync();
        }
    }
}
