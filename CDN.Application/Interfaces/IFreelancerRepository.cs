using CDN.Domain.Entities;

namespace CDN.Application.Interfaces
{
    public interface IFreelancerRepository
    {
        Task<IEnumerable<Freelancer>> GetAllAsync();
        Task<Freelancer?> GetByIdAsync(int id);
        Task AddAsync(Freelancer freelancer);
        Task UpdateAsync(Freelancer freelancer);
        Task DeleteAsync(Freelancer freelancer);
    }
}
