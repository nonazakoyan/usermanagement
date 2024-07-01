using BussinesLayer.Entities.StudentsUtilities;
using Microsoft.AspNetCore.Mvc;
using Usermanagement.Models.Requests.Students;
using Usermanagement.Models.Responses;
using Usermanagement.Models.Responses.Students;
using Usermanagement.Services.StudentServices;

namespace Usermanagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddStuden([FromBody] StudentReq model)
        {

            StudentRes res = await _studentService.AddStudent(model);
            if (res.StatusCode == 200)
                return Ok(res);

            return BadRequest(new BaseRes()
            {
                StatusCode = res.StatusCode,
                Message = res.Message,
            });
        }
        [HttpPost]
        public async Task<IActionResult> AddStudentJson([FromBody] StudentJsonReq model)
        {
            StudentRes res = await _studentService.AddStudentJsonAsync(model.Students);
            if (res.StatusCode == 200)
                return Ok(res);
            return BadRequest(new BaseRes()
            {
                StatusCode = res.StatusCode,
                Message = res.Message,
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetStudentById(int Id)
        {

            StudentAllInfoRes res = await _studentService.GetStudent(Id);
            if (res.StatusCode == 200)
                return Ok(res);

            return BadRequest(new BaseRes()
            {
                StatusCode = res.StatusCode,
                Message = res.Message
            });


        }
        [HttpGet]
        public async Task<IActionResult> GetStudentByGpa(int gpa)
        {
            StudentGpaRes res = await _studentService.GetStudentByGpa(gpa);
            if(res.StatusCode == 200)
                return Ok(res);
            return BadRequest(new BaseRes()
            {
                StatusCode = res.StatusCode,
                Message = res.Message
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentByCourse(int courseId)
        {
            StudentCourseRes res = await _studentService.GetStudentByCourse(courseId);
            if (res.StatusCode == 200)
                return Ok(res);
            return BadRequest(new BaseRes()
            {
                StatusCode = res.StatusCode,
                Message = res.Message
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentsGroupByCourseId(int  courseId)
        {
            StudentgroupRes res = await _studentService.GetStudentsGroupByCourseIdAsync(courseId);
            if (res.StatusCode == 200)
                return Ok(res);
            return BadRequest(new BaseRes()
            {
                StatusCode = res.StatusCode,
                Message = res.Message
            });

        }
        [HttpPatch]
        public async Task<IActionResult> DeleteStudentByUserId(int UserId)
        {
            BaseRes res = await _studentService.DeleteStudent(UserId);
            if (res.StatusCode == 200)
                return Ok(res);
            return BadRequest(new BaseRes()
            {
                StatusCode = res.StatusCode,
                Message = res.Message
            });
        }
    }
}
