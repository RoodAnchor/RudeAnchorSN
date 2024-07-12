using Microsoft.AspNetCore.Mvc;

namespace RudeAnchorSN.Controllers
{
    [Route("[controller]")]
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
