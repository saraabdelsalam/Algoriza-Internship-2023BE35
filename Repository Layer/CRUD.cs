using Core_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer
{
  public class CRUD<T>: CommonFunctions<T>, ICRUD<T> where T : class
    {
        public CRUD(ApplicationDbContext Context
            ):base(Context) { }
        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Context.Set<T>().Remove(entity));

        }
    }
}
