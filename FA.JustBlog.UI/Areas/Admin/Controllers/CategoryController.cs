using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.Service.category;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/{controller}")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(ICategoryService categoryService, IUnitOfWork unitOfWork)
        {
            _categoryService = categoryService;
            _unitOfWork = unitOfWork;
        }

        [Route("categories")]
        public IActionResult Categories()
        {

            var result = _categoryService.GetAll();

            return View(result.DataList.ToList());
        }

        //[Route("detail")]
        //[HttpGet]
        //public IActionResult Detail()
        //{
        //    return View();
        //}
        
        [Route("detail/{id}")]
        [HttpGet]
        public IActionResult Detail(Guid id)
        {
            var result = _unitOfWork.CategoryRepository.Find(id);

            return View(result);
        }

        [Route("delete/{id}")]
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var result = _unitOfWork.CategoryRepository.Find(id);

            return View(result);
        }
        
        [Route("delete/{id}")]
        [HttpPost]
        public IActionResult Delete(Guid id, Category category)
        {
            _unitOfWork.CategoryRepository.Delete(category);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Categories");
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
        public IActionResult Create(Category categoryModel)
        {

            _unitOfWork.CategoryRepository.Create(categoryModel);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Categories");

        }
        
        [Route("edit/{id}")]
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var result = _unitOfWork.CategoryRepository.Find(id);

            return View(result);
        }

        [Route("edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, Category categoryModel)
        {

            _unitOfWork.CategoryRepository.Update(categoryModel);
            _unitOfWork.SaveChanges();

            return RedirectToAction("Categories");

        }
    }
}
