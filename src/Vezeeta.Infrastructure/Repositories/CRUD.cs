

using Vezeeta.Domain.Contracts;
using Vezeeta.Infrastructure.Data;

namespace Vezeeta.Infrastructure.Repositories
{
    public class CRUD<T> : CommonFunctions<T>, ICRUD<T> where T : class
    {
        public CRUD(AppDbContext Context
            ) : base(Context) { }
        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Context.Set<T>().Remove(entity));

        }
    }
}
