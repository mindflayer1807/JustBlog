using FA.JustBlog.Core;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.Repository.IRepositories;

namespace FA.JustBlog.Repository.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(JustBlogContext dataContext) : base(dataContext)
        {
        }

        public Comment AddComment(Guid postId, string commentName, string commentEmail, string commentHeader, string commentText)
        {
            try
            {
                var comment = new Comment();
                comment.PostId = postId;
                comment.Email = commentEmail;
                comment.Name = commentName.Trim();
                comment.CommentTime = DateTime.Now;
                comment.CommentHeader = commentHeader.Trim();
                comment.CommentText = commentText.Trim();

                dbSet.Add(comment);
                dataContext.SaveChanges();

                return comment;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
            
        public bool AddComment(string commentText)
        {
            try
            {
                var comment = new Comment();
                comment.PostId = new Guid();
                comment.Name = "Unknown";
                comment.CommentHeader = "Unknown";
                comment.CommentText = commentText.Trim();

                dbSet.Add(comment);
                dataContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public IList<Comment> GetCommentsForPost(string title)
        {
            return dataContext.Comments
                .Join(dataContext.Posts, c => c.PostId, p => p.Id, (c, p) => new { Comment = c, Post = p })
                .Where(cp => cp.Post.Title.Trim().ToLower() == title.Trim().ToLower())
                .Select(cp => cp.Comment)
                .ToList();
        }
    }
}
