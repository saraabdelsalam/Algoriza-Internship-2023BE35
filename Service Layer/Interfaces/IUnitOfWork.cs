using Service_Layer.Interfaces.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Interfaces
{
    public interface IUnitOfWork
    {
        //define each repository here
        IDiscountCode discountCode { get; }
        Task SaveAsync();
    }
}
