using BusinessObjects.Dto.SystemAccount;
using BusinessObjects.Entities;
using Mapster;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implementation;

public class SystemAccountService : ISystemAccountService
{
    private readonly ISystemAccountRepository _systemAccountRepository;

    public SystemAccountService(ISystemAccountRepository systemAccountRepository) => _systemAccountRepository = systemAccountRepository;

    public async Task<IEnumerable<SystemAccountDto>> GetAllSystemAccountsAsync()
    {
        var systemAccounts = await _systemAccountRepository.GetAllSystemAccountsAsync();
        return systemAccounts.Adapt<IEnumerable<SystemAccountDto>>();
    }

    public async Task<SystemAccountDto> GetSystemAccountByIdAsync(Guid id)
    {
        var systemAccount = await _systemAccountRepository.GetSystemAccountByIdAsync(id);
        if (systemAccount == null)
        {
            throw new KeyNotFoundException($"SystemAccount with ID {id} not found");
        }
        return systemAccount.Adapt<SystemAccountDto>();
    }

    public async Task<SystemAccountDto?> CreateSystemAccountAsync(SystemAccountForCreationDto systemAccountDto)
    {
        var systemAccount = systemAccountDto.Adapt<SystemAccount>();
        var createdSystemAccount = await _systemAccountRepository.CreateSystemAccountAsync(systemAccount);
        return createdSystemAccount?.Adapt<SystemAccountDto>();
    }

    public async Task UpdateSystemAccountAsync(SystemAccountForUpdateDto systemAccountDto)
    {
        var systemAccount = systemAccountDto.Adapt<SystemAccount>();
        await _systemAccountRepository.UpdateSystemAccountAsync(systemAccount);
    }

    public async Task DeleteSystemAccountAsync(Guid id) => await _systemAccountRepository.DeleteSystemAccountAsync(id);
}