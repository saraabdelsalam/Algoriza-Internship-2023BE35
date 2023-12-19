
using System.Linq.Expressions;


namespace Vezeeta.Domain.Contracts
{
    public interface ICommonFunctions<T> : IBaseRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        bool Exist(Expression<Func<T, bool>> condition);


    }
}
