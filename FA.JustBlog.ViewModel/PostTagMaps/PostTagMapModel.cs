using FA.JustBlog.ViewModel.Posts;
using FA.JustBlog.ViewModel.Tags;

namespace FA.JustBlog.ViewModel.PostTagMaps
{
    public class PostTagMapModel
    {
        public Guid PostId { get; set; }
        public PostModel Post { get; set; }
        public Guid TagId { get; set; }
        public TagModel Tag { get; set; }
    }
}
