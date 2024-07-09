using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Mime;

namespace RudeAnchorSN.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        public FileController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<string> Upload([FromForm(Name = "ProfilePic")]IFormFile file)
        {
            var newFileName = $"{Guid.NewGuid()}.jpeg";
            var webRootPath = _environment.WebRootPath;
            var imgUrl = $"/img/user/{newFileName}";
            var imgPath = Path.Combine(webRootPath, "img", "user", newFileName);

            using (var stream = System.IO.File.Create(imgPath))
            {
                await file.CopyToAsync(stream);
            }

            return imgUrl;
        }
    }
}
