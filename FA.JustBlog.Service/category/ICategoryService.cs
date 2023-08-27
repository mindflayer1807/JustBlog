using FA.JustBlog.ViewModel.Categories;
using FA.JustBlog.ViewModel.Responses;

namespace FA.JustBlog.Service.category
{
    public interface ICategoryService
    {
        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        /// <returns>A response containing a result of type CategoryModel.</returns>
        ResponseResult<CategoryModel> GetAll();

        /// <summary>
        /// Finds a category by its unique identifier.
        /// </summary>
        /// <param name="categoryId">The unique identifier of the category.</param>
        /// <returns>A response containing a result of type CategoryModel.</returns>
        ResponseResult<CategoryModel> Find(Guid categoryId);

        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="model">The CategoryModel object representing the category to create.</param>
        /// <returns>A response containing a result of type CategoryModel.</returns>
        ResponseResult<CategoryModel> Create(CategoryModel model);

        /// <summary>
        /// Edits an existing category.
        /// </summary>
        /// <param name="model">The CategoryModel object representing the category to edit.</param>
        /// <returns>A response containing a result of type CategoryModel.</returns>
        ResponseResult<CategoryModel> Edit(CategoryModel model);

        /// <summary>
        /// Deletes a category by its unique identifier.
        /// </summary>
        /// <param name="categoryId">The unique identifier of the category to delete.</param>
        /// <returns>A response containing a result of type CategoryModel.</returns>
        ResponseResult<CategoryModel> Delete(Guid categoryId);
    }
}
