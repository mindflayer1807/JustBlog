using FA.JustBlog.Repository.Infrastructures;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        //[Route("index")]
        public IActionResult Index()
        {
            var posts = _unitOfWork.PostRepository.GetAll();

            return View(posts.ToList());
        }

        //[Route("about")]
        public IActionResult About()
        {
            return View();
        }

        //[Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}