using System;
using System.Linq.Expressions;

namespace Contracts
{
	public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> FindAll();
        Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

