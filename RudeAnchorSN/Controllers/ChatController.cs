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
                chat = new ChatModel();

                var currentUser = await _userService.GetUser(User?.Identity?.Name);
                var user = await _userService.GetUser(userId);
                var users = new List<UserModel>();

                if (currentUser != null)
                    users.Add(currentUser);

                if (user != null)
                    users.Add(user);

                chat.Users = users;
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
            int targetUserId,
            string content)
        {
            var user = await _userService.GetUser(User?.Identity?.Name);
            var targetUser = await _userService.GetUser(targetUserId);
            var chat = await _chatService.GetChat(chatId);

            if (chat is null)
                chat = await _chatService.StartChat(new List<UserModel>() { user, targetUser });

            var message = new MessageModel()
            {
                ChatId = chat.Id,
                AuthorId = user.Id,
                Created = DateTime.Now,
                Content = content
            };

            await _chatService.SendMessage(message);

            return RedirectToAction("Index", new { id = chat.Id });
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
