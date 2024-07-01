using Microsoft.AspNetCore.Mvc;
using Usermanagement.Models.Requests.Course;
using Usermanagement.Models.Responses;
using Usermanagement.Services.CourceService;

namespace Usermanagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] CourseReq model)
        {
            BaseRes res = await _courseService.AddCourseAsync(model);
            if(res.StatusCode == 200)
                return Ok(res);
            return BadRequest(res);
        }

        [HttpPatch]
        public async Task<IActionResult> DeleteCourse(int Id)
        {
            BaseRes res = await _courseService.DeleteCourseAsync(Id);
            if(res.StatusCode == 200)
                return Ok(res);
            return BadRequest(res);
        }

    }
}
