using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.ViewModel.Categories;
using FA.JustBlog.ViewModel.Responses;
using Microsoft.Extensions.Logging;

namespace FA.JustBlog.Service.category
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly ILogger<CategoryService> _logger;
        public CategoryService(IUnitOfWork uow, IMapper mapper, ILogger<CategoryService> logger)
        {
            this.uow = uow;
            this.mapper = mapper;
            _logger = logger;
        }

        public ResponseResult<CategoryModel> Create(CategoryModel model)
        {
            try
            {
                if (model == null)
                {
                    return new ResponseResult<CategoryModel>($"Create failed!");
                }
                if (string.IsNullOrWhiteSpace(model.Name))
                {
                    return new ResponseResult<CategoryModel>($"Create failed!");
                }
                if (model.Name.Length <= 5)
                {
                    return new ResponseResult<CategoryModel>($"Create failed!");
                }
                if (model.Description.Length <= 5)
                {
                    return new ResponseResult<CategoryModel>($"Create failed!");
                }
                if (model.UrlSlug.Length <= 5)
                {
                    return new ResponseResult<CategoryModel>($"Create failed!");
                }

                var result = uow.CategoryRepository.Find(model.Id);
                if (result == null)
                {
                    return new ResponseResult<CategoryModel>($"Can't find the category that has id = {model.Id}");
                }

                model.Description = model.Description.Replace("<p>", "").Replace("</p>", "");
                var entity = mapper.Map<Category>(model);

                uow.CategoryRepository.Create(entity);
                uow.SaveChanges();

                return new ResponseResult<CategoryModel>() { Data = model, Message = "Create successed!" };

            }
            catch (Exception)
            {
                return new ResponseResult<CategoryModel>($"Create failed!");
            }
        }

        public ResponseResult<CategoryModel> Delete(Guid categoryId)
        {
            try
            {
                if (categoryId == Guid.Empty)
                {
                    return new ResponseResult<CategoryModel>($"Delete failed!");
                }

                var result = uow.CategoryRepository.Find(categoryId);
                if (result == null)
                {
                    return new ResponseResult<CategoryModel>($"Can't find the category that has id = {categoryId}");
                }

                uow.CategoryRepository.Delete(categoryId);
                uow.SaveChanges();

                return new ResponseResult<CategoryModel>() { Message = "Delete successed!" };

            }
            catch (Exception)
            {
                return new ResponseResult<CategoryModel>($"Delete failed!");
            }
        }

        public ResponseResult<CategoryModel> Edit(CategoryModel model)
        {
            var category = mapper.Map<Category>(model);
            try
            {
                uow.CategoryRepository.Update(category);
                uow.SaveChanges();
                return new ResponseResult<CategoryModel>() { Message = "Update successed!" };
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return new ResponseResult<CategoryModel>($"Update failed!");
            }
        }

        public ResponseResult<CategoryModel> Find(Guid categoryId)
        {
            try
            {
                if (categoryId == Guid.Empty)
                {
                    return new ResponseResult<CategoryModel>($"Invalid CategoryId");
                }

                var result = uow.CategoryRepository.Find(categoryId);
                if (result == null)
                {
                    return new ResponseResult<CategoryModel>($"Can't find the category that has id = {categoryId}");
                }

                var model = mapper.Map<CategoryModel>(result);
                return new ResponseResult<CategoryModel> { Data = model, Message = "Find Successed!" };
            }
            catch (Exception)
            {
                return new ResponseResult<CategoryModel>($"Find failed!");
            }
        }

        public ResponseResult<CategoryModel> GetAll()
        {
            var result = uow.CategoryRepository.GetAll().ToList();
            if (result.Count() > 0)
            {
                var models = mapper.Map<IEnumerable<CategoryModel>>(result).ToList();

                return new ResponseResult<CategoryModel>() { DataList = models, Message = "Get all succssed!" };
            }

            return new ResponseResult<CategoryModel>($"No have any data!");
        }

    }
}
