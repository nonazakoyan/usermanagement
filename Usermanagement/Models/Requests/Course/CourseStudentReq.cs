namespace Usermanagement.Models.Requests.Course
{
    public class CourseStudentReq
    {
        public int CourseId { get; set; }
        public List<int> StudentsId { get; set; } = new List<int>();
    }
}
