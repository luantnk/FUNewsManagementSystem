﻿using System.Linq.Expressions;

namespace Repositories.Base.Interface;

public interface IRepositoryBase<T> where T : class
{
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}