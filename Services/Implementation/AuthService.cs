using Services.Interface;
using Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Services.Implementation;

public class AuthService : IAuthService
{
    private readonly ISystemAccountRepository _systemAccountRepository;

    public AuthService(ISystemAccountRepository systemAccountRepository) => _systemAccountRepository = systemAccountRepository;

    public async Task<bool> Login(string email, string password)
    {
        var account = await _systemAccountRepository.FindByCondition(sa => sa.Email == email && sa.AccountPassword == password)
            .FirstOrDefaultAsync();
        return account != null;
    }
}