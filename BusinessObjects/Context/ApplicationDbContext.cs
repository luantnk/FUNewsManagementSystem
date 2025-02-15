using BusinessObjects.Configurations.CategoryConfiguration;
using BusinessObjects.Configurations.NewsArticleConfiguration;
using BusinessObjects.Configurations.NewsTagConfiguration;
using BusinessObjects.Configurations.SystemAccountConfiguration;
using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessObjects.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=LUAN-TRAN\\SQLEXPRESS;Database=FUNewsManagementSystem;User Id=sa;Password=12345;TrustServerCertificate=True;");
        }
    }

    public DbSet<NewsArticle> NewsArticles { get; set; }
    public DbSet<SystemAccount> SystemAccounts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<NewsTag> NewsTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new NewsArticleConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new NewsTagConfiguration());
        modelBuilder.ApplyConfiguration(new SystemAccountConfiguration());
    }
}