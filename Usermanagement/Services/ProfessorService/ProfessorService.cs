using BussinesLayer.Entities;
using Usermanagement.Models.Requests.Professor;
using Usermanagement.Models.Responses;
using Usermanagement.Models.Responses.Professor;

namespace Usermanagement.Services.ProfessorService
{
    public class ProfessorService : IProfessorService
    {
        public async Task<BaseRes> DeleteProfessorAsync(int id)
        {
            Professor professor = new Professor() { Id = id };
            await professor.DeleteprofessorAsync();

            return new BaseRes()
            {
                StatusCode = 200,
                Message = "Ok",
            };
        }

        public async Task<BaseRes> AddProfessorToCourseAsync(ProfessorReq req)
        {
            Professor professor = new Professor();
            professor = await professor.AddProfessorToCourseAsync(req.ProfessorId, req.CourseId);
            if (professor.Id != null)
            {
                return new BaseRes()
                {
                    StatusCode = 200,
                    Message = "Ok",
                };
            }
            return new BaseRes()
            {
                StatusCode = 400,
                Message = professor.ErrMsg
            };
        }

        public async Task<ProfessorGetRes> GetProfessorAsync(int Id)
        {
            Professor professor = new Professor() { Id = Id };
            professor = await professor.GetProfessorAsync();
            if (professor.Id != null)
            {
                return new ProfessorGetRes()
                {
                    StatusCode = 200,
                    Message = "Ok",
                    Id = professor.Id,
                    FullName = professor.FullName,
                    Email = professor.Email,
                    Position = professor.Position,
                    Salary = professor.Salary,
                    TeachingCourses = professor.TeachingCourses,
                    TeachingSubjects = professor.TeachingSubjects
                };
            }
            else return new ProfessorGetRes()
            {
                StatusCode = 400,
                Message = professor.ErrMsg
            };
        }
    }
}

