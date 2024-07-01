using BussinesLayer.Entities.StudentsUtilities;
using Usermanagement.Models.Requests.Students;
using Usermanagement.Models.Responses;
using Usermanagement.Models.Responses.Students;

namespace Usermanagement.Services.StudentServices
{
    public interface IStudentService
    {
        public  Task<StudentRes> AddStudent(StudentReq req);
        public Task<StudentRes> AddStudentJsonAsync(List<StudentJsonApi> req);
        public Task<StudentAllInfoRes> GetStudent(int id);
        public Task<StudentGpaRes> GetStudentByGpa(int CourseId);
        public Task<StudentCourseRes> GetStudentByCourse(int courseId);
        public Task<StudentgroupRes> GetStudentsGroupByCourseIdAsync(int courseId);
        public Task<BaseRes> DeleteStudent(int id);
    }
}
