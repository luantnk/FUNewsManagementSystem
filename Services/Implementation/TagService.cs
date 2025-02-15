using BusinessObjects.Dto.Tag;
using BusinessObjects.Entities;
using Mapster;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implementation;

public class TagService : ITagService
{
    private readonly ITagRepository _tagRepository;

    public TagService(ITagRepository tagRepository) => _tagRepository = tagRepository;

    public async Task<IEnumerable<TagDto>> GetAllTagsAsync()
    {
        var tags = await _tagRepository.GetAllTagsAsync();
        return tags.Adapt<IEnumerable<TagDto>>();
    }

    public async Task<TagDto> GetTagByIdAsync(Guid id)
    {
        var tag = await _tagRepository.GetTagByIdAsync(id);
        if (tag == null)
        {
            throw new KeyNotFoundException($"Tag with ID {id} not found");
        }
        return tag.Adapt<TagDto>();
    }

    public async Task<TagDto?> CreateTagAsync(TagForCreationDto tagDto)
    {
        var tag = tagDto.Adapt<Tag>();
        var createdTag = await _tagRepository.CreateTagAsync(tag);
        return createdTag?.Adapt<TagDto>();
    }

    public async Task UpdateTagAsync(TagForUpdateDto tagDto)
    {
        var tag = tagDto.Adapt<Tag>();
        await _tagRepository.UpdateTagAsync(tag);
    }

    public async Task DeleteTagAsync(Guid id) => await _tagRepository.DeleteTagAsync(id);
}