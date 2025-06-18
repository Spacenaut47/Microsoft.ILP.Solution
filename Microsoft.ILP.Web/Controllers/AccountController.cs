using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.ILP.Web.Models;
using Microsoft.ILP.Web.Settings;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Microsoft.ILP.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly string _userServiceUrl;
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IOptions<ServiceEndpoints> options, IHttpClientFactory httpClientFactory)
        {
            _userServiceUrl = options.Value.UserService!;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var client = _httpClientFactory.CreateClient();

            var content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{_userServiceUrl}/login", content);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Invalid credentials";
                return View();
            }

            var json = await response.Content.ReadAsStringAsync();
            var tokenObj = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            HttpContext.Session.SetString("JWT", tokenObj["token"]);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JWT");
            return RedirectToAction("Login");
        }
    }
}
