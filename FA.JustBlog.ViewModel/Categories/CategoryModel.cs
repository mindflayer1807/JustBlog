using FA.JustBlog.ViewModel.Posts;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.ViewModel.Categories
{
    public class CategoryModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name  is required")]
        [MinLength(5, ErrorMessage = "Name must be more than 5 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "UrlSlug  is required")]
        [MinLength(5, ErrorMessage = "UrlSlug must be more than 5 characters")]
        public string UrlSlug { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MinLength(5, ErrorMessage = "Description must be more than 5 characters")]
        public string Description { get; set; }
        public ICollection<PostModel> Posts { get; set; }
    }
}
