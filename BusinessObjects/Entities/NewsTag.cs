using BusinessObjects.Entities;

public class NewsTag
{
    public Guid NewsArticleId { get; set; }
    public Guid TagId { get; set; }

    public NewsArticle? NewsArticle { get; set; }
    public Tag? Tag { get; set; }
}