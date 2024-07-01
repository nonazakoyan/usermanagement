using System.ComponentModel.DataAnnotations;

namespace Usermanagement.Models.Requests.Students
{
    public class StudentReq
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Email { get; set; }
        public int? Grade { get; set; }
        public int? Fee { get; set; }
        public int? Gpa { get; set; }
        public int? CourseId { get; set; }
    }
}
