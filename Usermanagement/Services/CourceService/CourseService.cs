using BussinesLayer.Entities;
using Usermanagement.Models.Requests.Course;
using Usermanagement.Models.Responses;

namespace Usermanagement.Services.CourceService
{
    public class CourseService : ICourseService
    {
        public async Task<BaseRes> AddCourseAsync(CourseReq req)
        {
            Course course = new Course() { Name = req.Name, Grade = req.Grade, Specialty = req.Specialty };
            await course.AddCourseAsync();
            if (course.Id !=  null) 
            {
                return new BaseRes()
                {
                    StatusCode = 200,
                    Message = "Ok"
                };
            }
            return new BaseRes()
            {
                StatusCode = 400,
                Message = course.ErrMsg
            };
        }
        public async Task<BaseRes> DeleteCourseAsync(int Id)
        {
            Course course = new Course() { Id = Id };
            await course.DeleteCourseAsync();
            return new BaseRes()
            {
                StatusCode = 200,
                Message = "Ok"
            };
        }
    }
}


