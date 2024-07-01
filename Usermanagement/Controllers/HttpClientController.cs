using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Usermanagement.Models.Requests.NewFolder;


namespace Usermanagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HttpClientController : ControllerBase
    {
        private static HttpClient _client = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7031/api/Auth/RegisterUser")
        };

        [HttpPost]
        public async Task<IActionResult> RegisterUserWithHttpClient()
        {
            RegisterReq requestdata = new RegisterReq()
            {
                FirstName = "string",
                LastName = "string",
                Birthday = new DateTime(2024, 06, 21),
                Email = "user@example.com",
                Password = "string",
                Salary = 0,
                Position = "string"
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(requestdata), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(_client.BaseAddress, content);

            string responseBody = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return Ok(responseBody);
            else
                return BadRequest($"Error: {responseBody}");
        }
    }
}
