using CommonEnitity.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        //private readonly IApiClient _apiClient;
        //public IActionResult Login()
        //{
        //    AppUser user = new AppUser();
        //    return View(user);
        //}
    }
}
