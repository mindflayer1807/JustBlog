using FA.JustBlog.ViewModel.Posts;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.ViewModel.Comments
{
    public class CommentModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name  is required")]
        [MinLength(5, ErrorMessage = "Name must be more than 5 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Name  is required")]
        [MinLength(5, ErrorMessage = "Name must be more than 5 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Comment Header  is required")]
        [MinLength(5, ErrorMessage = "Comment Header must be more than 5 characters")]
        public string CommentHeader { get; set; }

        public Guid PostId { get; set; }

        public PostModel? Post { get; set; }

        [Required(ErrorMessage = "Comment Text  is required")]
        [MinLength(5, ErrorMessage = "Comment Text must be more than 5 characters")]
        public string CommentText { get; set; }

        [Display(Name = "CommentTime")]
        [Required(ErrorMessage = "CommentTime is invalid!")]
        [DataType(DataType.Date, ErrorMessage = "CommentTime is invalid!")]
        public DateTime CommentTime { get; set; }
    }
}
