using BusinessObjects.Dto.Tag;

namespace Services.Interface;

public interface ITagService
{
    Task<IEnumerable<TagDto>> GetAllTagsAsync();
    Task<TagDto> GetTagByIdAsync(Guid id);
    Task<TagDto?> CreateTagAsync(TagForCreationDto tagDto);
    Task UpdateTagAsync(TagForUpdateDto tagDto);
    Task DeleteTagAsync(Guid id);
}