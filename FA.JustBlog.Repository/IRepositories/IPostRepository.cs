using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;

namespace FA.JustBlog.Repository.IRepositories
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        /// <summary>
        /// Get Post from Database by year, month and UrlSlug
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        Post FindPost(int year, int month, string urlSlug);

        /// <summary>
        /// Get Post from Database by postId
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        Post FindPost(Guid postId);

        /// <summary>
        /// Get all Posts from Database had published
        /// </summary>
        /// <returns></returns>
        IList<Post> GetPublisedPosts();

        /// <summary>
        /// Get all Posts from Database had not published
        /// </summary>
        /// <returns></returns>
        IList<Post> GetUnpublisedPosts();


        /// <summary>
        /// Get all Posts from Database by month
        /// </summary>
        /// <param name="monthYear"></param>
        /// <returns></returns>
        IList<Post> GetPostsByMonth(DateTime monthYear);

        /// <summary>
        /// Get number of Posts by CategeoryName
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int CountPostsForCategory(string category);

        /// <summary>
        /// Get number of Posts by TagName
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        int CountPostsForTag(string tag);

        /// <summary>
        /// Get all Posts from Database by CategoryName
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns> 
        IList<Post> GetPostsByCategory(string category);

        /// <summary>
        /// Get all Post from Database by TagName
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        IList<Post> GetPostByTag(string tag);
        /// <summary>
        /// Get Post by year, month and title
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="title"></param>
        /// <returns>Post</returns>
        Post GetPostByCondition(int year, int month, string title);

        /// <summary>
        /// Get Posts with latest posted
        /// </summary>
        /// <returns>Posts</returns>
        List<Post> LatestPosts();

        /// <summary>
        /// Get Posts most viewed
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Post> GetMostViewedPost(int size);
    }
}
