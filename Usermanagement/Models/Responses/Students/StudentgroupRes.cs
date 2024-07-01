using BussinesLayer.Entities.StudentsUtilities;

namespace Usermanagement.Models.Responses.Students
{
    public class StudentgroupRes : BaseRes
    {
        public List<StudentApi> Students {  get; set; } = new List<StudentApi>();
    }
}
