namespace FA.JustBlog.Core.Models
{
    public class Comment
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public Guid PostId { get; set; }

        public Post? Post { get; set; }

        public string CommentHeader { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentTime { get; set; }
    }
}
