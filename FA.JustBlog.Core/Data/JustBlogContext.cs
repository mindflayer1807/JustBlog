using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core
{
    public partial class JustBlogContext : IdentityDbContext
    {
        public JustBlogContext()
        {

        }
        public JustBlogContext(DbContextOptions<JustBlogContext> ops) : base(ops)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Category).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Comment).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Post).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Tag).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostTagMap).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GalleryImage).Assembly);
            modelBuilder.Seed();
            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source =.; Initial Catalog = JustBlog_TranVanHanh; Integrated Security = True";
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            //optionsBuilder.UseSqlServer("Server=.;Database=FAJustBlog;Integrated Security=True");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTagMap> PostTagMaps { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<GalleryImage> GalleryImages { get; set; }
    }
}
