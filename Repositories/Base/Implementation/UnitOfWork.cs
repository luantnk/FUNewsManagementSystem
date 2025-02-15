using BusinessObjects.Context;
using Repositories.Base.Interface;
using Repositories.Implementation;
using Repositories.Interface;

namespace Repositories.Base.Implementation;

public class UnitOfWork : IUnitOfWork
{   
    private readonly ApplicationDbContext _context;
    private INewsArticleRepository _newsArticleRepository;
    private ICategoryRepository _categoryRepository;
    private ISystemAccountRepository _systemAccountRepository;
    private ITagRepository _tagRepository;
    private INewsTagRepository _newsTagRepository;

    public UnitOfWork(ApplicationDbContext context) =>  _context = context;
    

    public INewsArticleRepository NewsArticles
    {
        get
        {
            _newsArticleRepository ??= new NewsArticleRepository(_context);
            return _newsArticleRepository;
        }
    }

    public ICategoryRepository Categories
    {
        get
        {
            _categoryRepository ??= new CategoryRepository(_context);
            return _categoryRepository;
        }
    }

    public ISystemAccountRepository SystemAccounts
    {
        get
        {
            _systemAccountRepository ??= new SystemAccountRepository(_context);
            return _systemAccountRepository;
        }
    }

    public ITagRepository Tags
    {
        get
        {
            _tagRepository ??= new TagRepository(_context);
            return _tagRepository;
        }
    }

    public INewsTagRepository NewsTags
    {
        get
        {
            _newsTagRepository ??= new NewsTagRepository(_context);
            return _newsTagRepository;
        }
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}