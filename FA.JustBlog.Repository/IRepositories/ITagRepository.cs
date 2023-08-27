using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;

namespace FA.JustBlog.Repository.IRepositories
{
    public interface ITagRepository : IBaseRepository<Tag>
    {
        /// <summary>
        /// Retrieves a Tag from the database based on the URL slug.
        /// </summary>
        /// <param name="urlSlug">The URL slug of the Tag.</param>
        /// <returns>The Tag object matching the URL slug.</returns>
        Tag GetTagByUrlSlug(string urlSlug);

        /// <summary>
        /// Retrieves popular tags from the database based on the specified count.
        /// </summary>
        /// <param name="size">The number of popular tags to retrieve.</param>
        /// <returns>A list of Tag objects representing popular tags.</returns>
        List<Tag> PopularTags(int size);

        /// <summary>
        /// Retrieves a Tag from the database based on the name.
        /// </summary>
        /// <param name="name">The name of the Tag.</param>
        /// <returns>The Tag object matching the name.</returns>
        Tag GetTagByName(string name);
    }
}
