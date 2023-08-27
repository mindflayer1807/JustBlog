using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using System.Web.Mvc;

namespace FA.JustBlog.Repository.IRepositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>A list of SelectListItem representing all categories.</returns>
        List<SelectListItem> GetAllCategories();

        /// <summary>
        /// Retrieves a category by its ID.
        /// </summary>
        /// <param name="id">The ID of the category.</param>
        /// <returns>The Category object with the specified ID.</returns>
        Category GetCategoryById(Guid id);

        /// <summary>
        /// Retrieves a category by its name.
        /// </summary>
        /// <param name="name">The name of the category.</param>
        /// <returns>The Category object with the specified name.</returns>
        Category GetCategoryByName(string name);
    }
}
