using BusinessObjects.Entities;

public class Category : AuditableEntity<Guid>
{
    public string? CategoryName { get; set; }
    public string? Description { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public int IsActive { get; set; }

    // Navigation properties
    public Category? ParentCategory { get; set; }
    public ICollection<Category>? SubCategories { get; set; }
    public ICollection<NewsArticle>? NewsArticles { get; set; }
}