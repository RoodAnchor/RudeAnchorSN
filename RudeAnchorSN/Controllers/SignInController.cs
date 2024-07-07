using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RudeAnchorSN.LogicLayer.Models;
using RudeAnchorSN.LogicLayer.Services;
using RudeAnchorSN.LogicLayer.Utils;
using System.Security.Authentication;
using System.Security.Claims;

namespace RudeAnchorSN.Controllers
{
    [Route("[controller]")]
    public class SignInController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public SignInController(
            ILogger<HomeController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserModel user)
        {
            if (string.IsNullOrEmpty(user.Email) ||
                string.IsNullOrEmpty(user.Password))
                throw new ArgumentNullException("Неверный запрос");

            var _user = await _userService.GetUser(user.Email);

            if (_user is null) throw new AuthenticationException($"Пользователь {user.Email} не найден");

            if (_user.Password != PasswordUtils.GetPasswordHash(user.Password))
                throw new AuthenticationException($"Неверный пароль");

            var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, _user.Email)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "AppCookie");

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Home");
        }
    }
}
