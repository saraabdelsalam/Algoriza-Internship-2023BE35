
using Vezeeta.Domain.Entities;

namespace Vezeeta.Domain.Contracts
{
    public interface IDiscountCodeRepository : ICRUD<DiscountCode>
    {
        DiscountCode GetByName(string CouponName);

    }
}
