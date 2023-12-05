using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository_Layer.Generic_Repo;

namespace Repository_Layer
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class

    {
        //inject DbContext class
        protected ApplicationDbContext Context;
        public BaseRepository(ApplicationDbContext repositoryContext)
        {

            Context = repositoryContext;
        }
      
      

        public Task<IQueryable<T>> GetAllAsync(int pageNumber, int pageSize, string search)
        {
            throw new NotImplementedException();
        }
        public T GetById(int id)
        {

            return Context.Set<T>().Find(id);
        }

        public T GetById(string id)
        {

            return Context.Set<T>().Find(id);
        }

    }
}
