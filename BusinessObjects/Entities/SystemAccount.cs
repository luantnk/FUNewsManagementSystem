namespace BusinessObjects.Entities;

public class SystemAccount : AuditableEntity<Guid>
{
    public string AccountName { get; set; }
    public string Email { get; set; }
    public string AccountRole { get; set; }
    public string AccountPassword { get; set; }
}