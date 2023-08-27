using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;

namespace FA.JustBlog.Repository.IRepositories
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        /// <summary>
        /// Add Comment to Database by postId, commentName, commentEmail, comment Header, comment Text
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="commentName"></param>
        /// <param name="commentEmail"></param>
        /// <param name="commentHeader"></param>
        /// <param name="commentText"></param>
        /// <return>Comment</return>
        Comment AddComment(Guid postId, string commentName, string commentEmail, string commentHeader, string commentText);

        /// <summary>
        /// Get all Comments from database by post title
        /// </summary>
        /// <param name="post title"></param>
        /// <returns></returns>
        IList<Comment> GetCommentsForPost(string title);

        /// <summary>
        /// add comment
        /// </summary>
        /// <param name="commentText"></param>
        /// <returns></returns>
        public bool AddComment(string commentText);
    }
}
