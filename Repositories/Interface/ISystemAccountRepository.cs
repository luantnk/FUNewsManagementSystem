using Repositories.Base.Interface;
using BusinessObjects.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Repositories.Interface
{
    public interface ISystemAccountRepository : IRepositoryBase<SystemAccount>
    {
        Task<IEnumerable<SystemAccount>> GetAllSystemAccountsAsync();
        Task<SystemAccount> GetSystemAccountByIdAsync(Guid id);
        Task<SystemAccount?> CreateSystemAccountAsync(SystemAccount systemAccount);
        Task UpdateSystemAccountAsync(SystemAccount systemAccount);
        Task DeleteSystemAccountAsync(Guid id);
    }
}