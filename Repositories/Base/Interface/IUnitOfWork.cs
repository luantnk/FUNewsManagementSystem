using Repositories.Interface;

namespace Repositories.Base.Interface;

public interface IUnitOfWork : IDisposable
{
    INewsArticleRepository NewsArticles { get; }
    ICategoryRepository Categories { get; }
    ISystemAccountRepository SystemAccounts { get; }
    ITagRepository Tags { get; }
    INewsTagRepository NewsTags { get; }
    Task SaveAsync();
}