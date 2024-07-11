using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RudeAnchorSN.LogicLayer.Services;
using RudeAnchorSN.LogicLayer.Models;

namespace RudeAnchorSN.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class FriendsController : Controller
    {
        private readonly ILogger<FriendsController> _logger;
        private readonly IUserService _userService;
        private readonly IFriendService _friendService;
        private readonly IRequestService _requestService;

        public FriendsController(
            ILogger<FriendsController> logger,
            IUserService userService,
            IFriendService friendService,
            IRequestService requestService)
        {
            _logger = logger;
            _userService = userService;
            _friendService = friendService;
            _requestService = requestService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUser(User.Identity.Name);
            var friends = new FriendsViewModel();

            friends.PendingRequests = await _requestService.GetPending(user.Id);
            friends.Friends = user.Friends;

            return View(friends);
        }

        [HttpGet]
        [Route("Add")]
        public async Task<IActionResult> Add()
        {
            var user = await _userService.GetUser(User.Identity.Name);
            var users = await _userService.GetUsers(user.Id);

            return View(users);
        }

        [HttpGet]
        [Route("Add/{id}")]
        public async Task<IActionResult> Add(int id)
        {
            var user = await _userService.GetUser(User.Identity.Name);
            var request = await _requestService.GetRequest(id, user.Id);

            if (request == null)
                await _requestService.SendRequest(id, user.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _userService.GetUser(User.Identity.Name);

            await _friendService.RemoveFriend(user.Id, id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Reject/{id}")]
        public async Task<IActionResult> Reject(int id)
        {
            var user = await _userService.GetUser(User.Identity.Name);
            var request = await _requestService.GetRequest(user.Id, id);

            await _requestService.Reject(request.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Accept/{id}")]
        public async Task<IActionResult> Accept(int id)
        {
            var user = await _userService.GetUser(User.Identity.Name);
            var request = await _requestService.GetRequest(user.Id, id);

            await _requestService.Accept(request.Id);
            await _friendService.AddFriend(user.Id, id);

            return RedirectToAction("Index");
        }
    }
}
