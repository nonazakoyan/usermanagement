using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Entities.StudentsUtilities
{
    public class StudentJsonApi
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Email { get; set; }
        public int? Grade { get; set; }
        public int? Fee { get; set; }
        public int? Gpa { get; set; }
        public int? CourseId { get; set; }
    }
}
