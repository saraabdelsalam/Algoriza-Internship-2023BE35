
using System.Linq.Expressions;

using Vezeeta.Domain.Contracts;
using Vezeeta.Infrastructure.Data;

namespace Vezeeta.Infrastructure.Repositories
{
    public class CommonFunctions<T> : BaseRepository<T>, ICommonFunctions<T> where T : class
    {
        public CommonFunctions(AppDbContext Context) : base(Context) { }
        public async Task AddAsync(T entity)
        {
            await Task.Run(() => Context.Set<T>().Add(entity));


        }
        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => Context.Set<T>().Update(entity));
        }


        public bool Exist(Expression<Func<T, bool>> condition)
        {
            return Context.Set<T>().Any(condition);
        }
    }
}
