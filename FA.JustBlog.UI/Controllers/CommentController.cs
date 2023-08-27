using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.Service.comment;
using FA.JustBlog.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.UI.Controllers
{
    [Route("{controller}")]
    public class CommentController : Controller
    {
        //[Route("index")]
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly IUnitOfWork _unitOfWork;

        public CommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("Comment/{title}")]
        public IActionResult GetCommentByPost(string title)
        {
            ViewBag.PostTitle = title;

            var comments = _unitOfWork.CommentRepository.GetCommentsForPost(title);

            return View(comments);
        }

        [HttpGet("/comment/add")]
        public IActionResult AddComment(Guid postId, string name, string email, DateTime commentTime, string commentHeader, string commentText)
        {
            _unitOfWork.CommentRepository.AddComment(postId, name, email, commentHeader, commentText);
            _unitOfWork.SaveChanges();

            return Json(new
            {
                Name = name,
                Email = email,
                CommentTime = commentTime,
                CommentHeader = commentHeader,
                CommentText = commentText
            });
        }

        [HttpGet]
        public IActionResult GetCommentTimeAgo(DateTime commentTime)
        {
            string timeAgo = TimeHelper.GetTimeCommentAgo(commentTime);
            return Json(new { timeAgo });
        }
    }
}
