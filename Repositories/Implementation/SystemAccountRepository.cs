using System.Linq.Expressions;
using BusinessObjects.Context;
using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Base.Implementation;
using Repositories.Interface;

namespace Repositories.Implementation;

public class SystemAccountRepository : RepositoryBase<SystemAccount>, ISystemAccountRepository
{
    public SystemAccountRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<SystemAccount>> GetAllSystemAccountsAsync()
    {
        return await FindAll()
            .OrderBy(sa => sa.AccountName)
            .ToListAsync();
    }

    public async Task<SystemAccount?> GetSystemAccountByIdAsync(Guid id)
    {
        return await FindByCondition(sa => sa.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<SystemAccount?> CreateSystemAccountAsync(SystemAccount systemAccount)
    {
        Create(systemAccount);
        await _context.SaveChangesAsync();
        return await GetSystemAccountByIdAsync(systemAccount.Id);
    }

    public async Task UpdateSystemAccountAsync(SystemAccount systemAccount)
    {
        var existingAccount = await _context.SystemAccounts
            .FirstOrDefaultAsync(sa => sa.Id == systemAccount.Id);

        if (existingAccount == null)
            throw new KeyNotFoundException($"SystemAccount with ID {systemAccount.Id} not found");
        _context.Entry(existingAccount).CurrentValues.SetValues(systemAccount);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSystemAccountAsync(Guid id)
    {
        var systemAccount = await _context.SystemAccounts
            .FirstOrDefaultAsync(sa => sa.Id == id);
        if (systemAccount == null)
            throw new KeyNotFoundException($"SystemAccount with ID {id} not found");
        Delete(systemAccount);
        await _context.SaveChangesAsync();
    }
}