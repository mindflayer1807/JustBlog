using FA.JustBlog.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.ViewModel.Posts
{
    public class PostModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MinLength(5, ErrorMessage = "Title must be more than 5 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ShortDescription is required")]
        [MinLength(5, ErrorMessage = "ShortDescription must be more than 5 characters")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "PostContent is required")]
        [MinLength(5, ErrorMessage = "PostContent must be more than 5 characters")]
        public string PostContent { get; set; }

        [Required(ErrorMessage = "UrlSlug is required")]
        [MinLength(5, ErrorMessage = "UrlSlug must be more than 5 characters")]
        public string UrlSlug { get; set; }

        [Display(Name = "Published")]
        public bool Published { get; set; }

        [Display(Name = "PostedOn")]
        [Required(ErrorMessage = "PostedOn is required")]
        [DataType(DataType.Date, ErrorMessage = "PostedOn is required")]
        public DateTime PostedOn { get; set; }

        [Required(ErrorMessage = "Name  is required")]
        [MinLength(5, ErrorMessage = "Name must be more than 5 characters")]
        public bool Modified { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
