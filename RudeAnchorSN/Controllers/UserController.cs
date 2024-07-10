using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RudeAnchorSN.LogicLayer.Models;
using RudeAnchorSN.LogicLayer.Services;

namespace RudeAnchorSN.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IRequestService _requestService;

        public UserController(
            ILogger<HomeController> logger,
            IUserService userService,
            IRequestService requestService)
        {
            _logger = logger;
            _userService = userService;
            _requestService = requestService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUser(User.Identity.Name);
            user.Requests = await _requestService.GetPending(user.Id);

            return View(user);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Index([FromRoute]int id)
        {
            var currentUser = await _userService.GetUser(User.Identity.Name);
            var user = await _userService.GetUser(id);

            user.Requests = await _requestService.GetPending(currentUser.Id);

            return View(user);
        }

        [HttpGet]
        [Route("Edit")]
        public async Task<IActionResult> Edit()
        {
            var user = await _userService.GetUser(User.Identity.Name);

            return View(user);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(UserModel user)
        {
            await _userService.UpdateUser(user);

            return RedirectToAction("Index");
        }
    }
}
