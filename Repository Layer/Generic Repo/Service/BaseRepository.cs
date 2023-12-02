using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Generic_Repo.Service
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class

    { 
        //inject DbContext class
        protected ApplicationDbContext RepositoryContext;
        public BaseRepository(ApplicationDbContext repositoryContext)
        {

         RepositoryContext = repositoryContext;
        }
        public async Task AddAsync(T entity)
        {
            await Task.Run(() => RepositoryContext.Set<T>().Add(entity));
            
        }
        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => RepositoryContext.Set<T>().Update(entity));
        }
        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => RepositoryContext.Set<T>().Remove(entity));

        }

        public Task<IQueryable<T>> GetAllAsync(int pageNumber, int pageSize, string search)
        {
            throw new NotImplementedException();
        }

       
    }
}
