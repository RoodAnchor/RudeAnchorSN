using Microsoft.AspNetCore.Mvc;

namespace RudeAnchorSN.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var userIdentity = User?.Identity;

            if (userIdentity != null && userIdentity.IsAuthenticated)
                return RedirectToAction("Index", "User");

            return View();
        }
    }
}
