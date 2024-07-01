using BussinesLayer.Entities.StudentsUtilities;

namespace Usermanagement.Models.Requests.Students
{
    public class StudentJsonReq
    {
        public List<StudentJsonApi> Students { get; set; } = new List<StudentJsonApi>();
    }
}
