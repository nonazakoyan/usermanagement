using System.ComponentModel.DataAnnotations;

namespace Usermanagement.Models.Requests.Professor
{
    public class ProfessorReq
    {
        [Required]
        public int ProfessorId { get; set; }
        [Required]
        public int CourseId { get; set; }
    }
}
