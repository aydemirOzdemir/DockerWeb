using DockerWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Diagnostics;

namespace DockerWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFileProvider fileProvider;

        public HomeController(ILogger<HomeController> logger,IFileProvider fileProvider)
        {
            _logger = logger;
            this.fileProvider = fileProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ImagesSave()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ImagesSave(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length>0)
            {
                var fileName=Guid.NewGuid().ToString()+Path.GetExtension(imageFile.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images",fileName);
                using (var stream=new FileStream(path,FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }


            }
            return View();
        }


        public IActionResult ImageShow() 
        {
            var images = fileProvider.GetDirectoryContents("wwwroot/images").ToList().Select(x=>x.Name);


            return View(images);
        }
        [HttpPost]
        public IActionResult ImageShow(string name)
        {
            var file = fileProvider.GetDirectoryContents("wwwroot/images").ToList().First(x=>x.Name==name);
            System.IO.File.Delete(file.PhysicalPath);


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}