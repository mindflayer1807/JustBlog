namespace FA.JustBlog.Core.Models
{
    public class GalleryImage
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}
