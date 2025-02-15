namespace BusinessObjects.Dto.Category;

public class CategoryForUpdateDto
{
    public string? CategoryName { get; set; }
    public string? Description { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public int IsActive { get; set; }
}