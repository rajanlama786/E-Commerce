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
using WebEcommerce.Models.ApiHelper;
using WebEcommerce.Models.Interfaces;
using CommonEnitity.DTOS;

namespace WebEcommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IConfiguration _configuration;
        private string ApiBaseUrl = string.Empty;
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly ApiClientFactory _clientFactory;

        public HomeController(ILogger<HomeController> logger, 
            IConfiguration configuration, 
            IHttpContextAccessor httpContextAccessor,
            IHttpClientFactory httpClient)
        {
            _logger = logger;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _clientFactory = new ApiClientFactory(httpClient, "Catalog");
            //ApiBaseUrl = _configuration["APIBase:BaseUrle"];
            //_httpClient = new()
            //{
            //    BaseAddress = new Uri(ApiBaseUrl)
            //};

        }

        //string jwt = "";//Request.Cookies["jwtCookie"];
        public async Task<string> GetToken(AppUser userData)
        {
            string jwt = string.Empty;
            string strAPIUrl = $"Token/Login";

            using (var response = await
                _httpClient.PostAsJsonAsync<AppUser>(strAPIUrl, userData))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    jwt = apiResponse;
                }
            }

            return jwt;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> GetList()
        {
            string strAPIUrl = $"Catalog/GetCatalogItemListAsync";
            StringContent content = new
                StringContent(JsonSerializer.Serialize(string.Empty),
                Encoding.UTF8, "text/plain");
            var objList = await
                _clientFactory.PostListAsync<CatalogItem>(strAPIUrl, content);
            return View(objList);
            
        }

        //[HttpGet("{id}")]
        public async Task<IActionResult> DeleteItem( string id)
        {
            string strAPIUrl = $"Catalog/CatalogItemDeleteAsync";
            StringContent content = new
                StringContent(JsonSerializer.Serialize(id),
                Encoding.UTF8, "text/plain");
            var objList = await
                _clientFactory.PostListAsync<CatalogItem>(strAPIUrl, content);
            //return View(objList);
            return RedirectToAction("GetList", "Home");
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

        public IActionResult Create()
        {
            return View();
        }


    }
}