using FA.JustBlog.Core;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.Repository.IRepositories;

namespace FA.JustBlog.Repository.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(JustBlogContext dataContext) : base(dataContext)
        {
        }

        public int CountPostsForCategory(string category)
        {
            var result = dataContext.Posts.Join(dataContext.Categories, x => x.CategoryId, y => y.Id, (x, y) => new
            {
                y.Name
            }).Count(x => x.Name.Contains(category, StringComparison.OrdinalIgnoreCase));//.Count();

            return result;
        }

        // ==,Equals

        public Post FindPost(int year, int month, string urlSlug)
        {
            return dataContext.Posts.FirstOrDefault(x => x.PostedOn.Year == year && x.PostedOn.Month == month && x.UrlSlug.ToLower().Trim().Contains(urlSlug.ToLower().Trim()))!;
        }
        
        public Post FindPost(Guid postId)
        {
            return dataContext.Posts.FirstOrDefault(x => x.Id == postId)!;
        }

        public IList<Post> GetPostsByCategory(string category)
        {
            return dataContext.Posts.Join(dataContext.Categories, x => x.CategoryId, y => y.Id, (x, y) => new
            {
                Post = x,
                Category = y
            }).Where(y => y.Category.Name == category).Select(x => x.Post).ToList();
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return dataContext.Posts.Where(x => x.PostedOn.Month == monthYear.Month).ToList();
        }


        public IList<Post> GetPublisedPosts()
        {
            return dataContext.Posts.Where(x => x.Published).ToList();
        }

        public IList<Post> GetUnpublisedPosts()
        {
            return dataContext.Posts.Where(x => !x.Published).ToList();
        }

        public Post GetPostByCondition(int year, int month, string title)
        {
            return dataContext.Posts.FirstOrDefault(x => x.PostedOn.Year == year && x.PostedOn.Month == month && x.Title.ToLower().Contains(title.ToLower()) == true)!;
        }

        public List<Post> LatestPosts()
        {
            return dataContext.Posts.OrderByDescending(x => x.PostedOn).Take(2).ToList();

        }

        public int CountPostsForTag(string tag)
        {
            var result = dataContext.Posts
                .Join(dataContext.PostTagMaps, p => p.Id, ptm => ptm.PostId, (p, ptm) => new { Post = p, PostTagMap = ptm })
                .Join(dataContext.Tags, ptm => ptm.PostTagMap.TagId, t => t.Id, (ptm, t) => new { Post = ptm.Post, Tag = t })
                .Where(pt => pt.Tag.Name.Equals(tag, StringComparison.OrdinalIgnoreCase))
                .Count();

            return result;
        }

        public IList<Post> GetPostByTag(string tag)
        {
            return dataContext.Posts
                .Join(dataContext.PostTagMaps, p => p.Id, ptm => ptm.PostId, (p, ptm) => new { Post = p, PostTagMap = ptm })
                .Join(dataContext.Tags, ptm => ptm.PostTagMap.TagId, t => t.Id, (ptm, t) => new { Post = ptm.Post, Tag = t })
                .Where(pt => pt.Tag.Name == tag)
                .Select(pt => pt.Post)
                .ToList();
        }

        public IList<Post> GetMostViewedPost(int size)
        {
            return dataContext.Posts.OrderByDescending(x => x.ViewCount).Take(size).ToList();
        }
    }
}
