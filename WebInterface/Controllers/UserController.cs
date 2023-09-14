using Microsoft.AspNetCore.Mvc;
using WebInterface.Models;
using Newtonsoft.Json;
using System.Reflection;

namespace WebInterface.Controllers
{
    public class UserController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7259/api");
        private readonly HttpClient _client;
        public UserController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        /// <summary>
        /// Method <c>Index</c> Gets Users Details
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            List<UserViewModel> userList = new List<UserViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/user/Get").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                userList = JsonConvert.DeserializeObject<List<UserViewModel>>(data);
            }
            return View(userList);
        }

        /// <summary>
        /// Method <c>Login</c> Login Authentication
        /// </summary>
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/user/Login/" + email + "/" + password).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    if (data == "Valid User")
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ViewData["Message"] = "Invalid Credentials!";
            return View();
        }

        /// <summary>
        /// Method <c>Login</c> Login Page View
        /// </summary>
        [HttpGet]
        public IActionResult Login()
        {
            ModelState.Clear();
            return View();
        }

    }
}
