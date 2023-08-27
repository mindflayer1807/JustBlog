using FA.JustBlog.Core;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Repository.Infrastructures;
using FA.JustBlog.Repository.IRepositories;

namespace FA.JustBlog.Repository.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(JustBlogContext dataContext) : base(dataContext)
        {
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return dataContext.Tags.
                FirstOrDefault(x => x.UrlSlug
                                      .ToLower()
                                      .Trim()
                                      .Contains(urlSlug.ToLower().Trim()))!;
        }

        public List<Tag> PopularTags(int size)
        {
            return dataContext.Tags.OrderByDescending(t => t.Count).Take(size).ToList();
        }

        public Tag GetTagByName(string name)
        {
            return dataContext.Tags.FirstOrDefault(c => c.Name.Trim().ToLower() == name.Trim().ToLower())!;
        }
    }
}
