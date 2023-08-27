using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;

namespace FA.JustBlog.Repository.IRepositories
{
    public interface IGalleryImageRepository : IBaseRepository<GalleryImage>
    {
        /// <summary>
        /// get Image by post title
        /// </summary>
        /// <param name="postTitle"></param>
        /// <returns></returns>
        List<GalleryImage> GetImageByPost(string postTitle);

        /// <summary>
        /// get image by name image
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        GalleryImage GetImageByName(string name);
    }
}
