namespace Usermanagement.Models.Responses.Professor
{
    public class ProfessorGetRes : BaseRes
    {
        public int? Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int? Salary { get; set; }
        public string? Position { get; set; }
        public string? TeachingCourses { get; set; }
        public string? TeachingSubjects { get; set; }
    }
}
