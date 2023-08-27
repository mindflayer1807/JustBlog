using FA.JustBlog.Repository.Infrastructures;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.UI.Controllers
{
    [Route("{controller}")]
    public class TagController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("index")]
        public IActionResult Index()
        {
            var tags = _unitOfWork.TagRepository.GetAll();

            return View(tags);
        }

        [Route("populartag")]
        public IActionResult PopularTags()
        {
            var popularTags = _unitOfWork.TagRepository.PopularTags(5);

            return View(popularTags);
        }
    }
}
