using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.Service.comment;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/{controller}")]
    public class CommentController : Controller
    {
        private readonly ICommentService _CommentService;
        private readonly IUnitOfWork _unitOfWork;

        public CommentController(ICommentService CommentService, IUnitOfWork unitOfWork)
        {
            _CommentService = CommentService;
            _unitOfWork = unitOfWork;
        }

        [Route("Comments")]
        public IActionResult Comments()
        {

            var result = _CommentService.GetAll();

            return View(result.DataList.ToList());
        }

        [Route("detail/{id}")]
        [HttpGet]
        public IActionResult Detail(Guid id)
        {
            var result = _unitOfWork.CommentRepository.Find(id);

            return View(result);
        }

        [Route("delete/{id}")]
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var result = _unitOfWork.CommentRepository.Find(id);

            return View(result);
        }

        [Route("delete/{id}")]
        [HttpPost]
        public IActionResult Delete(Guid id, Comment Comment)
        {
            _unitOfWork.CommentRepository.Delete(Comment);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Comments");
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
        public IActionResult Create(Comment CommentModel)
        {

            _unitOfWork.CommentRepository.Create(CommentModel);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Comments");

        }

        [Route("edit/{id}")]
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var result = _unitOfWork.CommentRepository.Find(id);

            return View(result);
        }

        [Route("edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Comment CommentModel)
        {

            _unitOfWork.CommentRepository.Update(CommentModel);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Comments");

        }
    }
}
