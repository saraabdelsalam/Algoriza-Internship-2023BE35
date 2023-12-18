
using Microsoft.EntityFrameworkCore;

using Vezeeta.Domain.Contracts;
using Vezeeta.Infrastructure.Data;

namespace Vezeeta.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class

    {
        //inject DbContext class
        protected AppDbContext Context;
        public BaseRepository(AppDbContext repositoryContext)
        {

            Context = repositoryContext;
        }




        public T GetById(int id)
        {

            return Context.Set<T>().Find(id);
        }

        public T GetById(string id)
        {

            return Context.Set<T>().Find(id);
        }

        public Task SaveAsync() => Context.SaveChangesAsync();

    }
}
