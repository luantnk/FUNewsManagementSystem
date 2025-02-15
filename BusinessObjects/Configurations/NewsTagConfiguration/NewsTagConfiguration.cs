using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessObjects.Configurations.NewsTagConfiguration;

public class NewsTagConfiguration : IEntityTypeConfiguration<NewsTag>
{
    public void Configure(EntityTypeBuilder<NewsTag> builder)
    {
        builder.HasKey(nt => new { nt.NewsArticleId, nt.TagId });

        builder.HasOne(nt => nt.NewsArticle)
            .WithMany(n => n.NewsTags)
            .HasForeignKey(nt => nt.NewsArticleId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(nt => nt.Tag)
            .WithMany(t => t.NewsTags)
            .HasForeignKey(nt => nt.TagId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}