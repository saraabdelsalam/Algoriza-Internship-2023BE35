using Core_Layer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer
{
    public class CommonFunctions<T> : BaseRepository<T>, ICommonFunctions<T> where T : class
    {
        public CommonFunctions(ApplicationDbContext Context) : base(Context) { }
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
