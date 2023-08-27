using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/{controller}")]
    public class ImageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ImageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("Images")]
        public IActionResult Images()
        {

            var result = _unitOfWork.GalleryImageRepository.GetAll();

            return View(result.ToList());
        }

        [Route("detail/{id}")]
        [HttpGet]
        public IActionResult Detail(Guid id)
        {
            var result = _unitOfWork.GalleryImageRepository.Find(id);

            return View(result);
        }

        [Route("delete/{id}")]
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var result = _unitOfWork.GalleryImageRepository.Find(id);

            return View(result);
        }

        [Route("delete/{id}")]
        [HttpPost]
        public IActionResult Delete(Guid id, GalleryImage Image)
        {
            _unitOfWork.GalleryImageRepository.Delete(Image);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Images");
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
        public IActionResult Create(GalleryImage ImageModel)
        {

            _unitOfWork.GalleryImageRepository.Create(ImageModel);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Images");

        }

        [Route("edit/{id}")]
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var result = _unitOfWork.GalleryImageRepository.Find(id);

            return View(result);
        }

        [Route("edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, GalleryImage ImageModel)
        {

            _unitOfWork.GalleryImageRepository.Update(ImageModel);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Images");

        }
    }
}
