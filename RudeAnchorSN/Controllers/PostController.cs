using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RudeAnchorSN.LogicLayer.Models;
using RudeAnchorSN.LogicLayer.Services;

namespace RudeAnchorSN.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IUserService _userService;
        private readonly IUserPostService _userPostService;

        public PostController(
            ILogger<PostController> logger,
            IUserService userService,
            IUserPostService userPostService)
        {
            _logger = logger;
            _userService = userService;
            _userPostService = userPostService;
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(
            string title, 
            string content)
        {
            var user = await _userService.GetUser(User?.Identity?.Name);

            if (user != null)
            {
                var newPost = new UserPostModel()
                {
                    UserId = user.Id,
                    DateCreated = DateTime.Now,
                    Title = title,
                    Content = content
                };

                await _userPostService.CreatePost(newPost);
            }

            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var post = await _userPostService.GetPost(id);

            return View(post);
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(UserPostModel newPost)
        {
            await _userPostService.UpdatePost(newPost);

            return RedirectToAction("Index", "User");
        }
    }
}
