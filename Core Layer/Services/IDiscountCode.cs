using Core_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Interfaces.Admin
{
    public interface IDiscountCode 
    {
        Task AddDiscountCode(DiscountCode discountCode);
        Task EditDiscountCode(DiscountCode discountCode);
        Task DeleteDiscountCode(int id);
        Task ChangeStatus(int id);

    }
}
