using FA.JustBlog.Core;
using FA.JustBlog.Repository.IRepositories;
using FA.JustBlog.Repository.Repositories;

namespace FA.JustBlog.Repository.Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JustBlogContext _context;
        private ICategoryRepository _categoryRepository;
        private IPostRepository _postRepository;
        private ICommentRepository _commentRepository;
        private ITagRepository _tagRepository;
        private IGalleryImageRepository _galleryImageRepository;

        public UnitOfWork(JustBlogContext context = null)
        {
            _context = context ?? new JustBlogContext();
        }

        public ICategoryRepository CategoryRepository => _categoryRepository ?? new CategoryRepository(_context);

        public IPostRepository PostRepository => _postRepository ?? new PostRepository(_context);

        public ICommentRepository CommentRepository => _commentRepository ?? new CommentRepository(_context);

        public ITagRepository TagRepository => _tagRepository ?? new TagRepository(_context);

        public IGalleryImageRepository GalleryImageRepository => _galleryImageRepository ?? new GalleryImageRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            this._context?.Dispose();
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
