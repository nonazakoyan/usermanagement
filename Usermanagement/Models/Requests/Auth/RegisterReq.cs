using System.ComponentModel.DataAnnotations;

namespace Usermanagement.Models.Requests.NewFolder
{
    public class RegisterReq
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateTime? Birthday { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public int? Salary { get; set; }
        public string? Position { get; set; }

    }
}
