
using Microsoft.EntityFrameworkCore;

namespace Vezeeta.Domain.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        //method overloading
        T GetById(int id);
        T GetById(string id);

        Task SaveAsync();



    }
}
