using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Entities.SubjectUtilities
{
    public class SubjectPaginByProfApi : IErrMsg
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? ErrMsg { get; set; }
    }
}
