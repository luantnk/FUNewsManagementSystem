using Repositories.Base.Interface;

namespace Repositories.Interface;

public interface INewsArticleRepository : IRepositoryBase<NewsArticle>
{
    Task<IEnumerable<NewsArticle>> GetAllNewsArticlesAsync();
    Task<NewsArticle> GetNewsArticleByIdAsync(Guid id);
    Task<NewsArticle?> CreateNewsArticleAsync(NewsArticle newsArticle);
    Task UpdateNewsArticleAsync(NewsArticle newsArticle);
    Task DeleteNewsArticleAsync(Guid id);
}