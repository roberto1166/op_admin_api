using System;
using Contracts;
using System.Linq.Expressions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected OperationsContext OperationsContext { get; set; }
        public RepositoryBase(OperationsContext operationsContext)
        {
            OperationsContext = operationsContext;
        }
        public async Task<IEnumerable<T>> FindAll() => await OperationsContext.Set<T>().AsNoTracking().ToListAsync();
        public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression) =>
            await OperationsContext.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        public void Create(T entity) => OperationsContext.Set<T>().Add(entity);
        public void Update(T entity) => OperationsContext.Set<T>().Update(entity);
        public void Delete(T entity) => OperationsContext.Set<T>().Remove(entity);
    }
}

