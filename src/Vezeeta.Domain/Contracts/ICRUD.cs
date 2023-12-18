

namespace Vezeeta.Domain.Contracts
{
    public interface ICRUD<T> : ICommonFunctions<T> where T : class
    {
        Task DeleteAsync(T entity);
    }
}
