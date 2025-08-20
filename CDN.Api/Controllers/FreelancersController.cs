using CDN.Application.DTOs;
using CDN.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDN.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FreelancersController : ControllerBase
    {
        private readonly IFreelancerService _service;

        public FreelancersController(IFreelancerService service)
        {
            _service = service;
        }

        // GET all
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FreelancerDto>>> GetFreelancers()
        {
            var freelancers = await _service.GetAllAsync();
            return Ok(freelancers);
        }

        // GET by id
        [HttpGet("{id}")]
        public async Task<ActionResult<FreelancerDto>> GetFreelancer(int id)
        {
            var freelancer = await _service.GetByIdAsync(id);
            if (freelancer == null) return NotFound();
            return Ok(freelancer);
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<FreelancerDto>> CreateFreelancer(FreelancerDto freelancer)
        {
            var created = await _service.CreateAsync(freelancer);
            return CreatedAtAction(nameof(GetFreelancer), new { id = created.Id }, created);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFreelancer(int id, FreelancerDto freelancer)
        {
            if (id != freelancer.Id) return BadRequest();

            await _service.UpdateAsync(id, freelancer);
            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFreelancer(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        // Archive
        [HttpPatch("{id}/archive")]
        public async Task<IActionResult> ArchiveFreelancer(int id)
        {
            await _service.ArchiveAsync(id);
            return NoContent();
        }

        // Unarchive
        [HttpPatch("{id}/unarchive")]
        public async Task<IActionResult> UnarchiveFreelancer(int id)
        {
            await _service.UnarchiveAsync(id);
            return NoContent();
        }

        // 🔎 SEARCH
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<FreelancerDto>>> SearchFreelancers([FromQuery] string query)
        {
            var results = await _service.SearchAsync(query);
            return Ok(results);
        }
    }
}
