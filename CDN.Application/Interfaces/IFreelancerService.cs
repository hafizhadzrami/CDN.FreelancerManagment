using CDN.Application.DTOs;

namespace CDN.Application.Interfaces
{
    public interface IFreelancerService
    {
        Task<IEnumerable<FreelancerDto>> GetAllAsync();
        Task<FreelancerDto?> GetByIdAsync(int id);
        Task<FreelancerDto> CreateAsync(FreelancerDto freelancer);
        Task<FreelancerDto?> UpdateAsync(int id, FreelancerDto freelancer);
        Task<bool> DeleteAsync(int id);
        Task<bool> ArchiveAsync(int id);
        Task<bool> UnarchiveAsync(int id);
        Task<IEnumerable<FreelancerDto>> SearchAsync(string query);
    }
}
