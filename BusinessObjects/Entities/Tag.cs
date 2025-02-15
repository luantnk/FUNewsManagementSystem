using BusinessObjects.Entities;

public class Tag : AuditableEntity<Guid>
{
    public Guid TagId { get; set; }
    public string? TagName { get; set; }
    public string? Note { get; set; }

    // Navigation property
    public ICollection<NewsTag>? NewsTags { get; set; }
}