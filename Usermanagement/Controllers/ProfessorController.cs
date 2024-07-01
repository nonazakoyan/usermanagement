using BussinesLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Usermanagement.Models.Requests.Professor;
using Usermanagement.Models.Responses;
using Usermanagement.Models.Responses.Professor;
using Usermanagement.Services.ProfessorService;

namespace Usermanagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;
        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpPatch]
        public async Task<IActionResult> DeleteProfessor(int Id)
        {
            BaseRes res = await _professorService.DeleteProfessorAsync(Id);
            if (res.StatusCode == 200)
                return Ok(res);
            return BadRequest(new BaseRes()
            {
                StatusCode = res.StatusCode,
                Message = res.Message
            });
        }
        [HttpPost]
        public async Task<IActionResult> AddProfessorToCourse(ProfessorReq model)
        {
            BaseRes res = await _professorService.AddProfessorToCourseAsync(model);
            if (res.StatusCode == 200)
                return Ok(res);
            return BadRequest(new BaseRes()
            {
                StatusCode = res.StatusCode,
                Message = res.Message
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetProfessorById(int Id)
        {
            ProfessorGetRes res = await _professorService.GetProfessorAsync(Id);
            if(res.StatusCode == 200)
                return Ok(res);
            return BadRequest(new BaseRes()
            {
                StatusCode = res.StatusCode,
                Message = res.Message
            });
        }
    }
}
