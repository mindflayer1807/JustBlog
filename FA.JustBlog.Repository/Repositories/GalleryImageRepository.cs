using FA.JustBlog.Core;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.Repository.IRepositories;

namespace FA.JustBlog.Repository.Repositories
{
    public class GalleryImageRepository : BaseRepository<GalleryImage>, IGalleryImageRepository
    {
        public GalleryImageRepository(JustBlogContext dataContext) : base(dataContext) { }

        public GalleryImage GetImageByName(string name)
        {
            return dataContext.GalleryImages.FirstOrDefault(c => c.Title.Trim().ToLower() == name.Trim().ToLower())!;
        }

        public List<GalleryImage> GetImageByPost(string postTitle)
        {
            return dataContext.GalleryImages
                .Join(dataContext.Posts, c => c.PostId, p => p.Id, (c, p) => new { GalleryImage = c, Post = p })
                .Where(cp => cp.Post.Title.Trim().ToLower() == postTitle.Trim().ToLower())
                .Select(cp => cp.GalleryImage)
                .ToList();
        }
    }
}
