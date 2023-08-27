namespace FA.JustBlog.Core.Models
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UrlSlug { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public ICollection<PostTagMap>? PostTagMaps { get; set; }
    }
}
