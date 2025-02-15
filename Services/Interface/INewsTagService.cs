using BusinessObjects.Dto.NewsTag;

namespace Services.Interface;

public interface INewsTagService
{
    Task<IEnumerable<NewsTagDto>> GetAllNewsTagsAsync();
    Task<NewsTagDto> GetNewsTagByIdAsync(Guid newsArticleId, Guid tagId);
    Task<NewsTagDto?> CreateNewsTagAsync(NewsTagForCreationDto newsTagDto);
    Task UpdateNewsTagAsync(NewsTagForUpdateDto newsTagDto);
    Task DeleteNewsTagAsync(Guid newsArticleId, Guid tagId);
}