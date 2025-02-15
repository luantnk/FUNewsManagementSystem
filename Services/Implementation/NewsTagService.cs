using BusinessObjects.Dto.NewsTag;
using BusinessObjects.Entities;
using Mapster;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implementation;

public class NewsTagService : INewsTagService
{
    private readonly INewsTagRepository _newsTagRepository;

    public NewsTagService(INewsTagRepository newsTagRepository) => _newsTagRepository = newsTagRepository;

    public async Task<IEnumerable<NewsTagDto>> GetAllNewsTagsAsync()
    {
        var newsTags = await _newsTagRepository.GetAllNewsTagsAsync();
        return newsTags.Adapt<IEnumerable<NewsTagDto>>();
    }

    public async Task<NewsTagDto> GetNewsTagByIdAsync(Guid newsArticleId, Guid tagId)
    {
        var newsTag = await _newsTagRepository.GetNewsTagByIdAsync(newsArticleId, tagId);
        if (newsTag == null)
        {
            throw new KeyNotFoundException($"NewsTag with NewsArticleId {newsArticleId} and TagId {tagId} not found");
        }
        return newsTag.Adapt<NewsTagDto>();
    }

    public async Task<NewsTagDto?> CreateNewsTagAsync(NewsTagForCreationDto newsTagDto)
    {
        var newsTag = newsTagDto.Adapt<NewsTag>();
        var createdNewsTag = await _newsTagRepository.CreateNewsTagAsync(newsTag);
        return createdNewsTag?.Adapt<NewsTagDto>();
    }

    public async Task UpdateNewsTagAsync(NewsTagForUpdateDto newsTagDto)
    {
        var newsTag = newsTagDto.Adapt<NewsTag>();
        await _newsTagRepository.UpdateNewsTagAsync(newsTag);
    }

    public async Task DeleteNewsTagAsync(Guid newsArticleId, Guid tagId) => await _newsTagRepository.DeleteNewsTagAsync(newsArticleId, tagId);
}