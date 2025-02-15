using BusinessObjects.Dto.NewsArticle;
using BusinessObjects.Entities;
using Mapster;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implementation;

public class NewsArticleService : INewsArticleService
{
    private readonly INewsArticleRepository _newsArticleRepository;

    public NewsArticleService(INewsArticleRepository newsArticleRepository) => _newsArticleRepository = newsArticleRepository;

    public async Task<IEnumerable<NewsArticleDto>> GetAllNewsArticlesAsync()
    {
        var newsArticles = await _newsArticleRepository.GetAllNewsArticlesAsync();
        return newsArticles.Adapt<IEnumerable<NewsArticleDto>>();
    }

    public async Task<NewsArticleDto> GetNewsArticleByIdAsync(Guid id)
    {
        var newsArticle = await _newsArticleRepository.GetNewsArticleByIdAsync(id);
        if (newsArticle == null)
        {
            throw new KeyNotFoundException($"NewsArticle with ID {id} not found");
        }
        return newsArticle.Adapt<NewsArticleDto>();
    }

    public async Task<NewsArticleDto?> CreateNewsArticleAsync(NewsArticleForCreationDto newsArticleDto)
    {
        var newsArticle = newsArticleDto.Adapt<NewsArticle>();
        var createdNewsArticle = await _newsArticleRepository.CreateNewsArticleAsync(newsArticle);
        return createdNewsArticle?.Adapt<NewsArticleDto>();
    }

    public async Task UpdateNewsArticleAsync(NewsArticleForUpdateDto newsArticleDto)
    {
        var newsArticle = newsArticleDto.Adapt<NewsArticle>();
        await _newsArticleRepository.UpdateNewsArticleAsync(newsArticle);
    }

    public async Task DeleteNewsArticleAsync(Guid id) =>  await _newsArticleRepository.DeleteNewsArticleAsync(id);
    
}