using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using MySql.Data.MySqlClient;
using System.Data;
using Usermanagement.Models.Requests.Subject;
using Usermanagement.Models.Responses;
using Usermanagement.Models.Responses.Subject;
using Usermanagement.Services.SubjectService;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Usermanagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        [HttpPost]
        public async Task<IActionResult> AddSubjectsAsync([FromBody] SubjectReq model)
        {
            SubjectRes res =  await _subjectService.AddSubjects(model);
            if (res.StatusCode == 200)
            {
                return Ok(res);
            }
            return BadRequest(new BaseRes()
            {
                StatusCode = res.StatusCode,
                Message = res.Message
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddSubjectToProfessor(SubjectProfessorReq model)
        {
            BaseRes res = await _subjectService.AddSubjectToProfessorAsync(model);

            if(res.StatusCode == 200)
                return Ok(res);
            return BadRequest(new BaseRes()
            {
                Message = res.Message,
                StatusCode = res.StatusCode
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddSubjectToCourse(SubjectCourseReq model)
        {
            BaseRes res = await _subjectService.AddSubjectToCourseAsync(model);
            if(res.StatusCode == 200)
                return Ok(res);
            return BadRequest(new BaseRes()
            {
                Message = res.Message,
                StatusCode = res.StatusCode
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetSubjectById(int Id)
        {
            BaseRes res = await _subjectService.GetSubjectAsync(Id);
            if (res.StatusCode == 200)
                return Ok(res);
            return BadRequest(new BaseRes()
            {
                Message = res.Message,
                StatusCode = res.StatusCode
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetSubjectPagingByProfessor([FromQuery]SubjectPaginProfessorReq model)
        {
            SubjectPaginProfessorRes res = await _subjectService.GetSubjectPagingByProfessorAsync(model);
            if(res.StatusCode == 200)
                return Ok(res.Subjects);
            return BadRequest(new BaseRes()
            {
                Message = res.Message,
                StatusCode = res.StatusCode
            });
        }

        [HttpPatch]
        public async Task<IActionResult> DeleteSubject([FromBody] SubjectDeleteReq model)
        {
            BaseRes res = await _subjectService.DeleteSubject(model);
            if(res.StatusCode == 200)
            {
                return Ok(res);
            }
            return BadRequest(new BaseRes()
            {
                StatusCode = res.StatusCode,
                Message = res.Message
            });
        }
    }
}
