

using Vezeeta.Domain.Contracts;
using Vezeeta.Domain.Entities;
using Vezeeta.Infrastructure.Data;

namespace Vezeeta.Infrastructure.Repositories
{
    public class DiscountCodeRepository : CRUD<DiscountCode>, IDiscountCodeRepository
    {
        public DiscountCodeRepository(AppDbContext context) : base(context) { }
        public DiscountCode GetByName(string Name)
        {
            return Context.Set<DiscountCode>().FirstOrDefault(s => s.Code == Name);
        }
    }
}
