using Repositories.Base.Interface;
using BusinessObjects.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Repositories.Interface
{
    public interface INewsTagRepository : IRepositoryBase<NewsTag>
    {
        Task<IEnumerable<NewsTag>> GetAllNewsTagsAsync();
        Task<NewsTag> GetNewsTagByIdAsync(Guid newsArticleId, Guid tagId);
        Task<NewsTag?> CreateNewsTagAsync(NewsTag newsTag);
        Task UpdateNewsTagAsync(NewsTag newsTag);
        Task DeleteNewsTagAsync(Guid newsArticleId, Guid tagId);
    }
}