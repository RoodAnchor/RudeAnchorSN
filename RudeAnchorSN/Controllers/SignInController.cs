using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RudeAnchorSN.DataLayer.Exceptions;
using RudeAnchorSN.LogicLayer.Services;
using System.Security.Authentication;
using System.Security.Claims;

namespace RudeAnchorSN.Controllers
{
    [Route("[controller]")]
    public class SignInController : Controller
    {
        private readonly ILogger<SignInController> _logger;
        private readonly IUserService _userService;

        public SignInController(
            ILogger<SignInController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {
            try
            {
                var _user = await _userService.AuthenticateUser(email, password);

                if (_user != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, _user?.Email)
                    };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "AppCookie");

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                }
            }
            catch (UserNotFoundException)
            {
                TempData["Error"] = "Пользователь не найден";

                return RedirectToAction("Index", "Home");
            }
            catch (AuthenticationException)
            {
                TempData["Error"] = "Неверный пароль";

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "User");
        }
    }
}
