using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RudeAnchorSN.LogicLayer.Services;

namespace RudeAnchorSN.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IUserPostService _userPostService;

        public UserController(
            ILogger<HomeController> logger,
            IUserService userService,
            IUserPostService userPostService)
        {
            _logger = logger;
            _userService = userService;
            _userPostService = userPostService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUser(User.Identity.Name);

            return View(user);
        }

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Index([FromRoute]int id)
        {
            var user = await _userService.GetUser(id);

            return View(user);
        }
    }
}
