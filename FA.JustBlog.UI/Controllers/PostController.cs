using FA.JustBlog.Repository.Infrastructures;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.UI.Controllers
{
    [Route("{controller}")]
    public class PostController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("index")]
        public IActionResult Index()
        {
            var posts = _unitOfWork.PostRepository.GetAll();

            return View(posts.ToList());
        }

        [Route("detail/{year}/{month}/{title}")]
        public IActionResult Detail(int year, int month, string title)
        {
            var result = _unitOfWork.PostRepository.GetPostByCondition(year, month, title);
            return View(result);
        }

        [Route("Category/{name}")]
        public IActionResult GetPostsByCategory(string name)
        {
            ViewBag.CategoryName = name;
            var result = _unitOfWork.PostRepository.GetPostsByCategory(name);

            return View(result);
        }

        [Route("Tag/{name}")]
        public IActionResult GetPostsByTag(string name)
        {
            ViewBag.TagName = name;
            var result = _unitOfWork.PostRepository.GetPostByTag(name);

            return View(result);
        }

        //[Route("mostviewedpost")]
        public IActionResult MostViewedPosts()
        {
            var posts = _unitOfWork.PostRepository.GetMostViewedPost(2);

            return View(posts);
        }

        //[Route("latestposts")]
        public IActionResult LatestPostsinside()
        {
            var posts = _unitOfWork.PostRepository.LatestPosts();

            return View(posts);
        }
    }
}
