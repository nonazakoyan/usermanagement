using Usermanagement.Models.Requests.Subject;
using Usermanagement.Models.Responses;
using Usermanagement.Models.Responses.Subject;

namespace Usermanagement.Services.SubjectService
{
    public interface ISubjectService
    {
        public Task<SubjectRes> AddSubjects(SubjectReq req);
        public Task<BaseRes> DeleteSubject(SubjectDeleteReq req);
        public Task<BaseRes> AddSubjectToProfessorAsync(SubjectProfessorReq req);
        public Task<BaseRes> AddSubjectToCourseAsync(SubjectCourseReq req);
        public Task<BaseRes> GetSubjectAsync(int Id);
        public Task<SubjectPaginProfessorRes> GetSubjectPagingByProfessorAsync(SubjectPaginProfessorReq req);
    }
}
