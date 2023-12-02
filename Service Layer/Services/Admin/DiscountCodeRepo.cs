using Core_Layer.Models;
using Repository_Layer;
using Repository_Layer.Generic_Repo.Service;
using Service_Layer.Interfaces.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services.Admin
{
   public class DiscountCodeRepo: BaseRepository<DiscountCode>, IDiscountCode
    {
        public DiscountCodeRepo(ApplicationDbContext context): base(context) { }

        public async Task AddDiscountCode(DiscountCode discountCode)
        {
            await AddAsync(discountCode);
        }

      
    }
}
