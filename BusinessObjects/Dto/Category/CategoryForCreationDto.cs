namespace BusinessObjects.Dto.Category;

public class CategoryForCreationDto
{
    public string? CategoryName { get; set; }
    public string? Description { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public int IsActive { get; set; }
}