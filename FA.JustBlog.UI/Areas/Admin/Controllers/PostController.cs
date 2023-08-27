using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.Service.post;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/{controller}")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IUnitOfWork _unitOfWork;

        public PostController(IPostService postService, IUnitOfWork unitOfWork)
        {
            _postService = postService;
            _unitOfWork = unitOfWork;
        }

        [Route("posts")]
        public IActionResult Posts()
        {

            var result = _postService.GetAll();

            return View(result.DataList.ToList());
        }

        [Route("detail/{id}")]
        [HttpGet]
        public IActionResult Detail(Guid id)
        {
            var result = _unitOfWork.PostRepository.Find(id);

            return View(result);
        }

        [Route("delete/{id}")]
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var result = _unitOfWork.PostRepository.Find(id);

            return View(result);
        }

        [Route("delete/{id}")]
        [HttpPost]
        public IActionResult Delete(Guid id, Post Post)
        {
            _unitOfWork.PostRepository.Delete(Post);
            _unitOfWork.SaveChanges();

            return RedirectToAction("posts");
        }

        [Route("create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post PostModel)
        {

            _unitOfWork.PostRepository.Create(PostModel);
            _unitOfWork.SaveChanges();

            return RedirectToAction("posts");

        }

        [Route("edit/{id}")]
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var result = _unitOfWork.PostRepository.Find(id);

            return View(result);
        }

        [Route("edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Post PostModel)
        {

            _unitOfWork.PostRepository.Update(PostModel);
            _unitOfWork.SaveChanges();

            return RedirectToAction("posts");

        }

        [Route("latestposts")]
        public IActionResult LatestPosts()
        {
            var posts = _unitOfWork.PostRepository.LatestPosts();

            return View(posts.ToList());
        }
    }
}
