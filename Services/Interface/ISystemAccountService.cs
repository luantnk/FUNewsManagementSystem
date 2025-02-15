using BusinessObjects.Dto.SystemAccount;

namespace Services.Interface;

public interface ISystemAccountService
{
    Task<IEnumerable<SystemAccountDto>> GetAllSystemAccountsAsync();
    Task<SystemAccountDto> GetSystemAccountByIdAsync(Guid id);
    Task<SystemAccountDto?> CreateSystemAccountAsync(SystemAccountForCreationDto systemAccountDto);
    Task UpdateSystemAccountAsync(SystemAccountForUpdateDto systemAccountDto);
    Task DeleteSystemAccountAsync(Guid id);
}