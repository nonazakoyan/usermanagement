using BussinesLayer.Entities;
using BussinesLayer.Entities.SubjectUtilities;
using Google.Protobuf.Collections;
using Usermanagement.Models.Requests.Subject;
using Usermanagement.Models.Responses;
using Usermanagement.Models.Responses.Subject;

namespace Usermanagement.Services.SubjectService
{
    public class SubjectService : ISubjectService
    {
        public async Task<SubjectRes> AddSubjects(SubjectReq req)
        {
            Subject _subject = new Subject() { Name = req.Name };
            _subject = await _subject.AddSubjectsAsync();

            if (_subject.Id != null)
            {            
                return new SubjectRes
                {
                    Id = _subject.Id,
                    StatusCode = 200,
                    Message = "Ok"
                };
            }
            return new SubjectRes
            {
                StatusCode = 400,
                Message = _subject.ErrMsg,
            };
        }
        public async Task<BaseRes> DeleteSubject(SubjectDeleteReq req)
        {
            Subject _subject = new Subject() { Id = req.Id };
            _subject = await _subject.DeleteSubjectAsync();
            if (_subject != null)
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
                Message = "Error: User not found.",
            };
        }
        public async Task<BaseRes> AddSubjectToProfessorAsync(SubjectProfessorReq req)
        {
            Subject subject = new Subject();
            subject = await subject.AddSubjectToProfessorAsync(req.ProfessorId, req.SubjectId);
            if(subject.Id != null)
            {
                return new BaseRes
                {
                    StatusCode = 200,
                    Message = "OK"
                };
            }
            return new BaseRes()
            {
                StatusCode = 400,
                Message = subject.ErrMsg,
            };
        }
        public async Task<BaseRes> AddSubjectToCourseAsync(SubjectCourseReq req)
        {
            Subject subject = new Subject();
            subject = await subject.AddSubjectToCourseAsync(req.CourseId, req.SubjectId);
            if (subject.Id != null)
            {
                return new BaseRes()
                {
                    StatusCode = 200,
                    Message = "OK"
                };
            }
            return new BaseRes()
            {
                StatusCode = 400,
                Message = subject.ErrMsg
            };
        }
        public async Task<BaseRes> GetSubjectAsync(int Id)
        {
            Subject subject = new Subject() { Id = Id };
            subject = await subject.GetSubjectAsync();
            if (subject.Id != null)
            {
                return new BaseRes()
                {
                    StatusCode = 200,
                    Message = "OK",
                };
            }
            return new BaseRes()
            {
                StatusCode = 400,
                Message = subject.ErrMsg
            };
        }
        public async Task<SubjectPaginProfessorRes> GetSubjectPagingByProfessorAsync(SubjectPaginProfessorReq req)
        {
            Subject subject = new Subject();
            List<SubjectPaginByProfApi> subjectList = new List<SubjectPaginByProfApi>();
            subjectList = await subject.GetSubjectPagingByProfessorAsync(req.professorId, req.viewCount, req.startIndex);
            if (subjectList != null)
                return new SubjectPaginProfessorRes()
                {
                    StatusCode = 200,
                    Message = "OK",
                    Subjects = subjectList
                };
            return new SubjectPaginProfessorRes()
            {
                StatusCode = 400,
                Message = subject.ErrMsg,
            };

        }
    }
}
