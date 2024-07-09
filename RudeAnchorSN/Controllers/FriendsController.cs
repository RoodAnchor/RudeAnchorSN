using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RudeAnchorSN.LogicLayer.Services;

namespace RudeAnchorSN.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class FriendsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IFriendService _friendService;

        public FriendsController(
            ILogger<HomeController> logger,
            IUserService userService,
            IFriendService friendService)
        {
            _logger = logger;
            _userService = userService;
            _friendService = friendService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUser(User.Identity.Name);
            var friends = await _friendService.GetFriends(user.Id);

            return View();
        }
    }
}
