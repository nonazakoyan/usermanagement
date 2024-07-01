using Usermanagement.Models.Requests.NewFolder;
using Usermanagement.Models.Responses.Auth;

namespace Usermanagement.Services.UserService
{
    public interface IAuthService
    {
        public Task<RegisterRes> RegisterAsync(RegisterReq req);
        public  Task<LoginRes> LoginAsync(LoginReq req);
    }
}
