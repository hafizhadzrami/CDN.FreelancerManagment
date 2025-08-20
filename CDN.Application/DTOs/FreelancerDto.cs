using System.ComponentModel.DataAnnotations;

namespace CDN.Application.DTOs
{
    public class FreelancerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username wajib diisi")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email wajib diisi")]
        [EmailAddress(ErrorMessage = "Format email tidak sah")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number wajib diisi")]
        [Phone(ErrorMessage = "Format nombor telefon tidak sah")]
        public string PhoneNumber { get; set; } = string.Empty;

        public bool IsArchived { get; set; } = false;

        // Tukar jadi List<string>
        public List<string> Skillsets { get; set; } = new();
        public List<string> Hobbies { get; set; } = new();
    }
}
