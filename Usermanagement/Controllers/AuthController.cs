using BussinesLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Usermanagement.Models.Requests.NewFolder;
using Usermanagement.Models.Responses;
using Usermanagement.Models.Responses.Auth;
using Usermanagement.Services.StudentService;
using Usermanagement.Services.UserService;

namespace Usermanagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterReq model)
        {
            RegisterRes res = await _authService.RegisterAsync(model);
            if (res.StatusCode == 200)
                return Ok(res);
            return BadRequest(new BaseRes()
            {
                StatusCode = res.StatusCode,
                Message = res.Message,
            });
        }
        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] LoginReq model)
        {
            LoginRes res = await _authService.LoginAsync(model);
            if (res.StatusCode == 200)
                return Ok(res);
            return BadRequest(new BaseRes()
            {
                StatusCode = res.StatusCode,
                Message = res.Message,
            });
        }

    }
}
