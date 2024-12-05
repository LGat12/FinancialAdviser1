using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FinancialAdviser.Models;

namespace FinancialAdviser.Services
{
    public interface IUserService
    {
        Task<Users> AuthenticateUserAsync(string email, string password);
    }

    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<Users> AuthenticateUserAsync(string email, string password)
        {
            var loginModel = new LoginModel { Email = email, Password = password };
            var response = await _httpClient.PostAsJsonAsync("api/User/authenticate", loginModel);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Users>();
            }

            return null; // Return null if authentication fails
        }

        public class LoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
