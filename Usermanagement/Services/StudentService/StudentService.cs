using BussinesLayer.Entities;
using BussinesLayer.Entities.StudentsUtilities;
using Usermanagement.Models.Requests.Students;
using Usermanagement.Models.Responses;
using Usermanagement.Models.Responses.Students;
using Usermanagement.Services.StudentServices;

namespace Usermanagement.Services.StudentService
{
    public class StudentService : IStudentService
    {
        public async Task<StudentRes> AddStudent(StudentReq req)
        {
            Student student = new Student
            {
                FirstName = req.FirstName,
                LastName = req.LastName,
                Birthday = req.Birthday,
                Email = req.Email,
                Grade = req.Grade,
                Fee = req.Fee,
                Gpa = req.Gpa,
                CourseId = req.CourseId
            };
            student = await student.AddStudentAsync();
            if (student.Id != null)
            {
                return new StudentRes
                {
                    Id = student.Id,
                    StatusCode = 200,
                    Message = "Ok"
                };
            }
            return new StudentRes()
            {
                StatusCode = 400,
                Message = student.ErrMsg
            };
        }
        public async Task<StudentRes> AddStudentJsonAsync(List<StudentJsonApi> req)
        {
            Student student = new Student();
            student = await student.AddStudentJsonAsync(req);
            if (student.Id != null)
                return new StudentRes()
                {
                    Id = student.Id,
                    StatusCode = 200,
                    Message = "Ok"
                };
            return new StudentRes()
            {
                StatusCode = 400,
                Message = student.ErrMsg
            };                               
        }
        public async Task<BaseRes> DeleteStudent(int id)
        {
            Student student = new Student() { Id = id };
            await student.DeleteStudentAsync();
            return new BaseRes()
            {
                StatusCode = 200,
                Message = "Ok",
            };
        }
        public async Task<StudentAllInfoRes> GetStudent(int id)
        {
            Student student = new Student() { Id = id };
            student = await student.GetStudentByIdAsync();
            if (student.Id != null)
            {
                return new StudentAllInfoRes
                {
                    Id = student.Id,
                    FullName = student.FullName,
                    Email = student.Email,
                    Gpa = student.Gpa,
                    Grade = student.Grade,
                    Fee = student.Fee,
                    CourseId = student.CourseId,
                    StatusCode = 200,
                    Message = "Ok",
                };
            }
            return new StudentAllInfoRes()
            {
                StatusCode = 400,
                Message = student.ErrMsg
            };

        }
        public async Task<StudentGpaRes> GetStudentByGpa(int gpa)
        {
            Student student = new Student() { Gpa = gpa };
            student = await student.GetStudentByGpaAsync();
            if (student.Count != null) 
            {
                return new StudentGpaRes
                {
                    StatusCode = 200,
                    Message = "Ok",
                    FullNames = student.FullName,
                    StudentCounts = student.Count
                };
            }
            return new StudentGpaRes()
            {
                StatusCode = 400,
                Message = student.ErrMsg
            };
        }
        public async Task<StudentCourseRes> GetStudentByCourse(int courseId)
        {
            Student student = new Student() { CourseId = courseId };
            List<StudentsByCourseApi> studentsList = new List<StudentsByCourseApi>();
            studentsList = await student.GetStudentByCourseAsync();
            if (studentsList != null) 
            {
                return new StudentCourseRes
                {
                    StatusCode = 200,
                    Message = "Ok",
                    students = studentsList
                };
            }
            return new StudentCourseRes()
            {
                StatusCode = 400,
                Message = student.ErrMsg
            };
        }
        public async Task<StudentgroupRes> GetStudentsGroupByCourseIdAsync(int courseId)
        {
            Student student = new Student() { CourseId = courseId };
            student = await student.GetStudentsGroupdAsync();
            if (student.Students.Count != 0) 
            {
                return new StudentgroupRes
                {
                    StatusCode = 200,
                    Message = "Ok",
                    Students = student.Students
                };
            }
            return new StudentgroupRes()
            {
                StatusCode = 400,
                Message = "Students list is empty"
            };
        }
    }
}
