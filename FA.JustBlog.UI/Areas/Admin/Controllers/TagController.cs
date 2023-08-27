using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.Service.tag;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/{controller}")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        private readonly IUnitOfWork _unitOfWork;

        public TagController(ITagService tagService, IUnitOfWork unitOfWork)
        {
            _tagService = tagService;
            _unitOfWork = unitOfWork;
        }

        [Route("Tags")]
        public IActionResult Tags()
        {

            var result = _tagService.GetAll();

            return View(result.DataList.ToList());
        }

        [Route("detail/{id}")]
        [HttpGet]
        public IActionResult Detail(Guid id)
        {
            var result = _unitOfWork.TagRepository.Find(id);

            return View(result);
        }

        [Route("delete/{id}")]
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var result = _unitOfWork.TagRepository.Find(id);

            return View(result);
        }

        [Route("delete/{id}")]
        [HttpPost]
        public IActionResult Delete(Guid id, Tag Tag)
        {
            _unitOfWork.TagRepository.Delete(Tag);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Tags");
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
        public IActionResult Create(Tag TagModel)
        {

            _unitOfWork.TagRepository.Create(TagModel);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Tags");

        }

        [Route("edit/{id}")]
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var result = _unitOfWork.TagRepository.Find(id);

            return View(result);
        }

        [Route("edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Tag TagModel)
        {

            _unitOfWork.TagRepository.Update(TagModel);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Tags");

        }
    }
}
