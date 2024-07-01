using Usermanagement.Models.Requests.Professor;
using Usermanagement.Models.Responses;
using Usermanagement.Models.Responses.Professor;

namespace Usermanagement.Services.ProfessorService
{
    public interface IProfessorService
    {
        public Task<BaseRes> DeleteProfessorAsync(int id);
        public Task<BaseRes> AddProfessorToCourseAsync(ProfessorReq req);
        public Task<ProfessorGetRes> GetProfessorAsync(int Id);
    }
}
