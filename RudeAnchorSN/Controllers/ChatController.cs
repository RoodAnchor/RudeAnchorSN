using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RudeAnchorSN.LogicLayer.Models;
using RudeAnchorSN.LogicLayer.Services;
using System;

namespace RudeAnchorSN.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;
        private readonly IUserService _userService;
        private readonly ILogger<ChatController> _logger;

        public ChatController(
            IChatService chatService,
            IUserService userService,
            ILogger<ChatController> logger)
        {
            _chatService = chatService;
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Index(int id, [FromQuery]int userId)
        {
            var chat = await _chatService.GetChat(id);
            
            if (chat is null)
            {
                var currentUser = await _userService.GetUser(User?.Identity?.Name);
                var user = await _userService.GetUser(userId);
                var users = new List<UserModel>();

                if (currentUser != null)
                    users.Add(currentUser);

                if (user != null)
                    users.Add(user);

                chat = await _chatService.StartChat(users);

                return RedirectToAction("Index", new { chat.Id });
            }

            var lastMessage = chat?.Messages?.LastOrDefault();

            if (lastMessage != null && lastMessage?.Author?.Email != User?.Identity?.Name)
                await _chatService.MarkAsRead(chat.Id);

            return View(chat);
        }

        [HttpPost]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(
            int chatId,
            string content)
        {
            var user = await _userService.GetUser(User?.Identity?.Name);

            if (user is null) return RedirectToAction("Index", new { id = chatId });

            var message = new MessageModel()
            {
                ChatId = chatId,
                AuthorId = user.Id,
                Created = DateTime.Now,
                Content = content
            };

            await _chatService.SendMessage(message);

            return RedirectToAction("Index", new { id = chatId });
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _chatService.RemoveChat(id);

            return RedirectToAction("Index", "Messages");
        }
    }
}
