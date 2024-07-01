using BussinesLayer.Entities.SubjectUtilities;

namespace Usermanagement.Models.Responses.Subject
{
    public class SubjectPaginProfessorRes : BaseRes
    {
        public List<SubjectPaginByProfApi> Subjects = new List<SubjectPaginByProfApi>();
    }
}
