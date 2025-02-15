namespace BusinessObjects.Dto.NewsArticle;

public class NewsArticleForUpdateDto
{
    public Guid NewsArticleId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid CreatedById { get; set; }
    public Guid UpdatedById { get; set; }
    public string? NewsTitle { get; set; }
    public string? Headline { get; set; }
  
    public string? NewsContent { get; set; }
    public string? NewsSource { get; set; }
    public string? NewsStatus { get; set; }
}