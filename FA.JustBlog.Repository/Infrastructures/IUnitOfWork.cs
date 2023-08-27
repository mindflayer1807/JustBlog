using FA.JustBlog.Repository.IRepositories;

namespace FA.JustBlog.Repository.Infrastructures
{
    public interface IUnitOfWork : IDisposable
    {
        public ICategoryRepository CategoryRepository { get; } // read only
        public IPostRepository PostRepository { get; }
        public ICommentRepository CommentRepository { get; }
        public ITagRepository TagRepository { get; }

        public IGalleryImageRepository GalleryImageRepository { get; }

        int SaveChanges();
    }
}
