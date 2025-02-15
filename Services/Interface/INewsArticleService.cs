using BusinessObjects.Dto.NewsArticle;

namespace Services.Interface;

public interface INewsArticleService
{
    Task<IEnumerable<NewsArticleDto>> GetAllNewsArticlesAsync();
    Task<NewsArticleDto> GetNewsArticleByIdAsync(Guid id);
    Task<NewsArticleDto?> CreateNewsArticleAsync(NewsArticleForCreationDto newsArticle);
    Task UpdateNewsArticleAsync(NewsArticleForUpdateDto newsArticle);
    Task DeleteNewsArticleAsync(Guid id);
}