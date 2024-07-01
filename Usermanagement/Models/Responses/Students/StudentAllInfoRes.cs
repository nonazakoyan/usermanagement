namespace Usermanagement.Models.Responses.Students
{
    public class StudentAllInfoRes : BaseRes
    {
        public int? Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int? Grade { get; set; }
        public int? Fee { get; set; }
        public int? Gpa { get; set; }
        public int? CourseId { get; set; }
    }
}
