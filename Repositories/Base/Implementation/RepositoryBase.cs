using System.Linq.Expressions;
using BusinessObjects.Context;
using Microsoft.EntityFrameworkCore;
using Repositories.Base.Interface;

namespace Repositories.Base.Implementation;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected ApplicationDbContext _context;

    public RepositoryBase(ApplicationDbContext context) => _context = context;

    public IQueryable<T> FindAll() => _context.Set<T>().AsNoTracking();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
        _context.Set<T>().Where(expression).AsNoTracking();

    public void Create(T entity) => _context.Set<T>().Add(entity);

    public void Update(T entity) => _context.Set<T>().Update(entity);
    public void Delete(T entity) => _context.Set<T>().Remove(entity);
}