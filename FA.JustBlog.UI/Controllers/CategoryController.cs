using FA.JustBlog.Repository.Infrastructures;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.UI.Controllers
{
    [Route("{controller}")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("index")]
        public IActionResult Index()
        {
            var categories = _unitOfWork.CategoryRepository.GetAllCategories();

            return View(categories);
        }

        //[Route("detail/{id}")]
        //public IActionResult Detail(Guid id)
        //{
        //    var result = _unitOfWork.CategoryRepository.Find(id);

        //    if (result == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(result);
        //}
    }
}
