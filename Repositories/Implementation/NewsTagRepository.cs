using System.Linq.Expressions;
using BusinessObjects.Context;
using Microsoft.EntityFrameworkCore;
using Repositories.Base.Implementation;
using Repositories.Interface;

namespace Repositories.Implementation;

public class NewsTagRepository : RepositoryBase<NewsTag>, INewsTagRepository
{
    public NewsTagRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<NewsTag>> GetAllNewsTagsAsync()
    {
        return await FindAll()
            .ToListAsync();
    }

    public async Task<NewsTag?> GetNewsTagByIdAsync(Guid newsArticleId, Guid tagId)
    {
        return await FindByCondition(nt => nt.NewsArticleId == newsArticleId && nt.TagId == tagId)
            .FirstOrDefaultAsync();
    }

    public async Task<NewsTag?> CreateNewsTagAsync(NewsTag newsTag)
    {
        Create(newsTag);
        await _context.SaveChangesAsync();
        return await GetNewsTagByIdAsync(newsTag.NewsArticleId, newsTag.TagId);
    }

    public async Task UpdateNewsTagAsync(NewsTag newsTag)
    {
        var existingNewsTag = await _context.NewsTags
            .FirstOrDefaultAsync(nt => nt.NewsArticleId == newsTag.NewsArticleId && nt.TagId == newsTag.TagId);

        if (existingNewsTag == null)
            throw new KeyNotFoundException($"NewsTag with NewsArticleId {newsTag.NewsArticleId} and TagId {newsTag.TagId} not found");
        _context.Entry(existingNewsTag).CurrentValues.SetValues(newsTag);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteNewsTagAsync(Guid newsArticleId, Guid tagId)
    {
        var newsTag = await _context.NewsTags
            .FirstOrDefaultAsync(nt => nt.NewsArticleId == newsArticleId && nt.TagId == tagId);
        if (newsTag == null)
            throw new KeyNotFoundException($"NewsTag with NewsArticleId {newsArticleId} and TagId {tagId} not found");
        Delete(newsTag);
        await _context.SaveChangesAsync();
    }
}