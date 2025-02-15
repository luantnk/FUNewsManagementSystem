using Repositories.Base.Interface;
using BusinessObjects.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Repositories.Interface
{
    public interface ITagRepository : IRepositoryBase<Tag>
    {
        Task<IEnumerable<Tag>> GetAllTagsAsync();
        Task<Tag> GetTagByIdAsync(Guid id);
        Task<Tag?> CreateTagAsync(Tag tag);
        Task UpdateTagAsync(Tag tag);
        Task DeleteTagAsync(Guid id);
    }
}