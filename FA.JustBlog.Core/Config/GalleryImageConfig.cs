using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Config
{
    public class GalleryImageConfig : IEntityTypeConfiguration<GalleryImage>
    {
        public void Configure(EntityTypeBuilder<GalleryImage> builder)
        {
            builder.ToTable("GalleryImages");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");
            builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1024);
            builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(255);
            builder.HasOne(x => x.Post).WithMany(x => x.GalleryImages).HasForeignKey(x => x.PostId);
        }
    }
}
