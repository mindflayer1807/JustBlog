using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.JustBlog.Core.Config
{
    public class PostTagMapConfig : IEntityTypeConfiguration<PostTagMap>
    {
        public void Configure(EntityTypeBuilder<PostTagMap> builder)
        {
            builder.ToTable("PostTagMaps");
            builder.HasKey(x => new { x.PostId, x.TagId });
            builder.HasOne(x => x.Post)
                .WithMany(x => x.PostTagMaps)
                .HasForeignKey(x => x.PostId);
            builder.HasOne(x => x.Tag)
                .WithMany(x => x.PostTagMaps)
                .HasForeignKey(x => x.TagId);
        }
    }
}
