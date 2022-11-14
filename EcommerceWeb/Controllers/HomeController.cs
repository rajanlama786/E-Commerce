using CommonEnitity.Catalog;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebEcommerce.Models;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using CommonEnitity.Users;
using System.Xml.Linq;

namespace WebEcommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IConfiguration _configuration;
        private string ApiBaseUrl = string.Empty;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            ApiBaseUrl = _configuration["APIBase:BaseUrle"];
        }

        //string jwt = "";//Request.Cookies["jwtCookie"];
        public async Task<string> GetToken(AppUser userData)
        {
            string jwt = string.Empty;            
            string strAPIUrl = $"{ApiBaseUrl}Token/Login";
            using (var httpClient = new HttpClient())
            {
                using (var response = await
                    httpClient.PostAsJsonAsync<AppUser>(strAPIUrl, userData))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        jwt = apiResponse;
                    }
                }
            }
            return jwt;
        }
        public async Task<IActionResult> Index()
        {
            
            AppUser userData = new AppUser();
            userData.EmailID = "alokgo@gmail.com";
            userData.UserName = "alokgo@gmail.com";
            userData.Password = "alokpandey";
            userData.DisplayName = "Alok Pandey";
            userData.AddedOn = DateTime.Now;
            userData.UserId = 1;
            

            string jwt = await GetToken(userData);
            StringContent content = new
                StringContent(JsonSerializer.Serialize(string.Empty),
                Encoding.UTF8, "text/plain");
            string strAPIUrl = $"{ApiBaseUrl}Catalog/GetCatalogItemListAsync";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization
                    = new AuthenticationHeaderValue("Bearer", jwt);
                using (var response = await
                    httpClient.PostAsJsonAsync(strAPIUrl, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        IEnumerable<CatalogItem> objList =
                            JsonSerializer.Deserialize<IEnumerable<CatalogItem>>(apiResponse);
                        return View(objList);
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> GetList()
        {
            string apiUrl = "https://localhost:7264/api/Token/";
            AppUser userData = new AppUser();
            userData.UserName = "alokgo@gmail.com";
            userData.Password = "alokpandey";
            userData.DisplayName = "Alok Pandey";
            userData.AddedOn = DateTime.Now;
            userData.UserId = 1;
            using (HttpClient httpClient = new HttpClient()) 
            {
                httpClient.BaseAddress = new Uri(apiUrl);
                using (HttpResponseMessage response =
                    await httpClient.PostAsJsonAsync<AppUser>("Login", userData))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}