using BussinesLayer.Entities;
using BussinesLayer.Entities.StudentsUtilities;
using Newtonsoft.Json;

namespace Usermanagement.Models.Responses.Students
{
    public class StudentCourseRes : BaseRes
    {
        [JsonProperty("students")]
        public List<StudentsByCourseApi> students = new List<StudentsByCourseApi>();
    }
}
