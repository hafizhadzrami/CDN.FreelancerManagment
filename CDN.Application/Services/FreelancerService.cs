using CDN.Application.DTOs;
using CDN.Application.Interfaces;
using CDN.Domain.Entities;

namespace CDN.Application.Services
{
    public class FreelancerService : IFreelancerService
    {
        private readonly IFreelancerRepository _repository;

        public FreelancerService(IFreelancerRepository repository)
        {
            _repository = repository;
        }

        // ✅ Helper mapper: Entity -> DTO
        private static FreelancerDto MapToDto(Freelancer f)
        {
            return new FreelancerDto
            {
                Id = f.Id,
                Username = f.Username,
                Email = f.Email,
                PhoneNumber = f.PhoneNumber,
                IsArchived = f.IsArchived,
                Skillsets = f.Skillsets.Select(s => s.Name).ToList(),
                Hobbies = f.Hobbies.Select(h => h.Name).ToList()
            };
        }

        // ✅ Helper mapper: DTO -> Entity
        private static Freelancer MapToEntity(FreelancerDto dto)
        {
            return new Freelancer
            {
                Id = dto.Id,
                Username = dto.Username,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                IsArchived = dto.IsArchived,
                Skillsets = dto.Skillsets.Select(s => new Skillset { Name = s }).ToList(),
                Hobbies = dto.Hobbies.Select(h => new Hobby { Name = h }).ToList()
            };
        }

        public async Task<IEnumerable<FreelancerDto>> GetAllAsync()
        {
            var freelancers = await _repository.GetAllAsync();
            return freelancers.Select(MapToDto);
        }

        public async Task<FreelancerDto?> GetByIdAsync(int id)
        {
            var f = await _repository.GetByIdAsync(id);
            return f == null ? null : MapToDto(f);
        }

        public async Task<FreelancerDto> CreateAsync(FreelancerDto dto)
        {
            var entity = MapToEntity(dto);

            await _repository.AddAsync(entity);

            return MapToDto(entity);
        }

        public async Task<FreelancerDto?> UpdateAsync(int id, FreelancerDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            // update simple fields
            entity.Username = dto.Username;
            entity.Email = dto.Email;
            entity.PhoneNumber = dto.PhoneNumber;
            entity.IsArchived = dto.IsArchived;

            // reset children (clear + re-add)
            entity.Skillsets.Clear();
            entity.Hobbies.Clear();

            foreach (var s in dto.Skillsets)
                entity.Skillsets.Add(new Skillset { Name = s, FreelancerId = id });

            foreach (var h in dto.Hobbies)
                entity.Hobbies.Add(new Hobby { Name = h, FreelancerId = id });

            await _repository.UpdateAsync(entity);

            return MapToDto(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(entity);
            return true;
        }

        public async Task<bool> ArchiveAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            entity.IsArchived = true;
            await _repository.UpdateAsync(entity);
            return true;
        }

        public async Task<bool> UnarchiveAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            entity.IsArchived = false;
            await _repository.UpdateAsync(entity);
            return true;
        }

        public async Task<IEnumerable<FreelancerDto>> SearchAsync(string query)
        {
            var all = await _repository.GetAllAsync();
            return all
                .Where(f =>
                    f.Username.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    f.Email.Contains(query, StringComparison.OrdinalIgnoreCase))
                .Select(MapToDto);
        }
    }
}
