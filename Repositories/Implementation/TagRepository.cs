using System.Linq.Expressions;
using BusinessObjects.Context;
using Microsoft.EntityFrameworkCore;
using Repositories.Base.Implementation;
using Repositories.Interface;

namespace Repositories.Implementation;

public class TagRepository : RepositoryBase<Tag>, ITagRepository
{
    public TagRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Tag>> GetAllTagsAsync()
    {
        return await FindAll()
            .OrderBy(t => t.TagName)
            .ToListAsync();
    }

    public async Task<Tag?> GetTagByIdAsync(Guid id)
    {
        return await FindByCondition(t => t.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<Tag?> CreateTagAsync(Tag tag)
    {
        Create(tag);
        await _context.SaveChangesAsync();
        return await GetTagByIdAsync(tag.Id);
    }

    public async Task UpdateTagAsync(Tag tag)
    {
        var existingTag = await _context.Tags
            .FirstOrDefaultAsync(t => t.Id == tag.Id);

        if (existingTag == null)
            throw new KeyNotFoundException($"Tag with ID {tag.Id} not found");
        _context.Entry(existingTag).CurrentValues.SetValues(tag);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTagAsync(Guid id)
    {
        var tag = await _context.Tags
            .FirstOrDefaultAsync(t => t.Id == id);
        if (tag == null)
            throw new KeyNotFoundException($"Tag with ID {id} not found");
        Delete(tag);
        await _context.SaveChangesAsync();
    }
}