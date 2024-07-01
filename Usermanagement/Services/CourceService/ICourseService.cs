using Usermanagement.Models.Requests.Course;
using Usermanagement.Models.Responses;

namespace Usermanagement.Services.CourceService
{
    public interface ICourseService
    {
        public Task<BaseRes> AddCourseAsync(CourseReq req);
        public Task<BaseRes> DeleteCourseAsync(int Id);

    }
}
