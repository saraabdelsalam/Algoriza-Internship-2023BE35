using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Generic_Repo
{
    public interface IBaseRepository< T> where T : class
{
        Task<IQueryable<T>> GetAllAsync(int pageNumber, int pageSize, string search);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);



}
}
