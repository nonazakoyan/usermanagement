using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Entities.StudentsUtilities
{
    public class StudentsByCourseApi : IErrMsg
    {
        public int? Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int? Grade { get; set; }
        public int? Fee { get; set; }
        public int? Gpa { get; set; }
        public string ErrMsg { get; set; }
    }
}
