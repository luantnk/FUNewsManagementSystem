using BusinessObjects.Entities;

public class NewsArticle : AuditableEntity<Guid>
{ 
    public Guid CategoryId { get; set; }
    public Guid CreatedById { get; set; }
    public Guid UpdatedById { get; set; }
    public string? NewsTitle { get; set; }
    public string? Headline { get; set; }
  
    public string? NewsContent { get; set; }
    public string? NewsSource { get; set; }
    public string? NewsStatus { get; set; }

    // Navigation properties
    public SystemAccount? CreatedBy { get; set; }
    public SystemAccount? UpdatedBy { get; set; }
    public Category? Category { get; set; }
    public ICollection<NewsTag>? NewsTags { get; set; }
}