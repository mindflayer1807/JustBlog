using FA.JustBlog.Repository.Infrastructures;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.UI.Controllers
{
    [Route("{controller}")]
    public class GalleryImageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GalleryImageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("index")]
        public IActionResult Index()
        {
            var images = _unitOfWork.GalleryImageRepository.GetAll();
            return View(images);
        }

        [Route("GalleryImage/{title}")]
        public IActionResult GetGalleryByPost(string title)
        {
            ViewBag.Title = title;
            var images = _unitOfWork.GalleryImageRepository.GetImageByPost(title);

            return View(images.ToList());
        }
    }
}
