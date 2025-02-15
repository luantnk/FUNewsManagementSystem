using System.Linq.Expressions;
using BusinessObjects.Context;
using Microsoft.EntityFrameworkCore;
using Repositories.Base.Implementation;
using Repositories.Interface;

namespace Repositories.Implementation;

public class NewsArticleRepository : RepositoryBase<NewsArticle>, INewsArticleRepository
{
    public NewsArticleRepository(ApplicationDbContext context) : base(context)
    {
    }

     public async Task<IEnumerable<NewsArticle>> GetAllNewsArticlesAsync()
    {
        return await FindAll()
            .OrderByDescending(n => n.CreatedDate)
            .ToListAsync();
    }

    public async Task<NewsArticle?> GetNewsArticleByIdAsync(Guid id)
    {
        return await FindByCondition(n => n.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<NewsArticle?> CreateNewsArticleAsync(NewsArticle newsArticle)
    {
        Create(newsArticle);
        await _context.SaveChangesAsync();
        return await GetNewsArticleByIdAsync(newsArticle.Id);
    }

    public async Task UpdateNewsArticleAsync(NewsArticle newsArticle)
    {
        var existingArticle = await _context.NewsArticles
            .Include(n => n.NewsTags)
            .FirstOrDefaultAsync(n => n.Id == newsArticle.Id);

        if (existingArticle == null)
            throw new KeyNotFoundException($"NewsArticle with ID {newsArticle.Id} not found");
        if (existingArticle.NewsTags != null)
        {
            _context.NewsTags.RemoveRange(existingArticle.NewsTags);
        }
        _context.Entry(existingArticle).CurrentValues.SetValues(newsArticle);
        if (newsArticle.NewsTags != null)
        {
            foreach (var newsTag in newsArticle.NewsTags)
            {
                newsTag.NewsArticleId = newsArticle.Id;
                _context.NewsTags.Add(newsTag);
            }
        }
        await _context.SaveChangesAsync();
    }

    public async Task DeleteNewsArticleAsync(Guid id)
    {
        var newsArticle = await _context.NewsArticles
            .Include(n => n.NewsTags)
            .FirstOrDefaultAsync(n => n.Id == id);
        if (newsArticle == null)
            throw new KeyNotFoundException($"NewsArticle with ID {id} not found");
        if (newsArticle.NewsTags != null)
        {
            _context.NewsTags.RemoveRange(newsArticle.NewsTags);
        }
        Delete(newsArticle);
        await _context.SaveChangesAsync();
    }

}