using FA.JustBlog.Core;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.Repository.IRepositories;
using System.Web.Mvc;

namespace FA.JustBlog.Repository.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(JustBlogContext dataContext) : base(dataContext)
        {
        }

        public List<SelectListItem> GetAllCategories()
        {
            List<SelectListItem> categories = new List<SelectListItem>();

            try
            {
                var data = dataContext.Categories.Select(category => new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name,
                }).ToList();

                categories = data;
            }
            catch (Exception)
            {
            }

            return categories;
        }

        public Category GetCategoryById(Guid id)
        {
            return dataContext.Categories.FirstOrDefault(c => c.Id == id)!;
        }

        public Category GetCategoryByName(string name)
        {
            return dataContext.Categories.FirstOrDefault(c => c.Name.Trim().ToLower() == name.Trim().ToLower())!;
        }
    }
}
