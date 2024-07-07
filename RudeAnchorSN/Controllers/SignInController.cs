using Microsoft.AspNetCore.Mvc;

namespace RudeAnchorSN.Controllers
{
    public class SignInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
