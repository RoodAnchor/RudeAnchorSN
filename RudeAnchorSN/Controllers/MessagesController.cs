using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RudeAnchorSN.LogicLayer.Models;
using RudeAnchorSN.LogicLayer.Services;

namespace RudeAnchorSN.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class MessagesController : Controller
    {
        private readonly IChatService _chatService;
        private readonly IUserService _userService;
        private readonly ILogger<MessagesController> _logger;

        public MessagesController(
            IChatService chatService,
            IUserService userService,
            ILogger<MessagesController> logger)
        {
            _chatService = chatService;
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUser(User?.Identity?.Name);

            var chats = new List<ChatModel>();

            if (user != null)
                chats = await _chatService.GetChats(user.Id);

            return View(chats);
        }
    }
}
