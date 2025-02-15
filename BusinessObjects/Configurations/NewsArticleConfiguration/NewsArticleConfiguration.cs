using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessObjects.Configurations.NewsArticleConfiguration;

public class NewsArticleConfiguration : IEntityTypeConfiguration<NewsArticle>
{
    public void Configure(EntityTypeBuilder<NewsArticle> builder)
    {
        builder.HasKey(n => n.Id);

        builder.Property(n => n.NewsTitle)
            .HasMaxLength(200);

        builder.Property(n => n.Headline)
            .HasMaxLength(500);

        builder.Property(n => n.NewsContent)
            .HasMaxLength(2000);

        builder.Property(n => n.NewsSource)
            .HasMaxLength(100);

        builder.Property(n => n.NewsStatus)
            .HasMaxLength(50);

        builder.HasOne(n => n.CreatedBy)
            .WithMany()
            .HasForeignKey(n => n.CreatedById)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(n => n.UpdatedBy)
            .WithMany()
            .HasForeignKey(n => n.UpdatedById)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(n => n.Category)
            .WithMany(c => c.NewsArticles)
            .HasForeignKey(n => n.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}