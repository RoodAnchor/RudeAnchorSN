using Microsoft.AspNetCore.Mvc;
using RudeAnchorSN.LogicLayer.Models;
using RudeAnchorSN.LogicLayer.Services;

namespace RudeAnchorSN.Controllers
{
    [Route("[controller]")]
    public class SignUpController : Controller
    {
        private readonly ILogger<SignUpController> _logger;
        private readonly IUserService _userService;

        public SignUpController(
            ILogger<SignUpController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index(UserModel user)
        {
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserModel user)
        {
            await _userService.RegisterUser(user);

            return RedirectToAction("index", "Home");
        }
    }
}
