using Core_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Layer.Repository
{
    public interface IDiscountCodeRepository:ICRUD<DiscountCode>
    {
        DiscountCode GetByName(string CouponName);
      
    }
}
