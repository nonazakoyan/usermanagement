using BussinesLayer.Entities;
using Usermanagement.Models.Requests.NewFolder;
using Usermanagement.Models.Responses.Auth;

namespace Usermanagement.Services.UserService
{
    public class AuthService : IAuthService
    {
        public async Task<RegisterRes> RegisterAsync(RegisterReq req)
        {
            Professor professsor = new Professor()
            {
                FirstName = req.FirstName,
                LastName = req.LastName,
                Birthday = req.Birthday,
                Email = req.Email,
                Password = req.Password,
                Salary = req.Salary,
                Position = req.Position
            };
            professsor = await professsor.AddRegisterProfessorAsync();
            if (professsor.Id != null)
                return new RegisterRes()
                {
                    StatusCode = 200,
                    Message = "Ok",
                    Id = professsor.Id
                };
            return new RegisterRes() 
            {
                StatusCode = 400,
                Message = professsor.ErrMsg,
            };
        }
        public async Task<LoginRes> LoginAsync(LoginReq req)
        {
            Professor professor = new Professor() { Email = req.Email, Password = req.Password };
            professor = await professor.LoginUser();
            if (professor.Id != null)
            {
                return new LoginRes()
                {
                    StatusCode = 200,
                    Message = "Ok",
                    Id = professor.Id
                };
            }
            return new LoginRes()
            {
                StatusCode = 400,
                Message = professor.ErrMsg,
            };
        }

    }
}
