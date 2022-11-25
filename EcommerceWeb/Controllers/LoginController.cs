using CommonEnitity.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using WebEcommerce.Models.ApiHelper;
using WebEcommerce.Models.Helper;

namespace WebEcommerce.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApiClientFactory _clientFactory;
        public LoginController(
            IHttpContextAccessor httpContextAccessor,
            IHttpClientFactory httpClient)
        {
            _httpContextAccessor = httpContextAccessor;
            _clientFactory = new ApiClientFactory(httpClient, "Catalog");
        }
        // GET: LoginController
        public ActionResult Index()
        {
            AppUser user = new AppUser();
            return View(user);
        }

        public ActionResult Logout()
        {
            CookieHelper cookieHelper = new CookieHelper(new HttpContextAccessor());
            cookieHelper.LogOutTokenCookie();
            return RedirectToAction("Index", "Login");
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(IFormCollection collection)
        {
            try
            {
                AppUser user = new AppUser()
                {
                    UserId = 0,
                    DisplayName = string.Empty,
                    EmailID = string.Empty,
                    AddedOn = DateTime.Now,
                    UserName = collection["UserName"].ToString().Trim(),
                    Password = collection["Password"].ToString().Trim(),
                };

                string jwt = string.Empty;               

                jwt = await _clientFactory.GetToken(user);

                return RedirectToAction("GetList", "Home");//nameof(HomeController.GetList)
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        



        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
