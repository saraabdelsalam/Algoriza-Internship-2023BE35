using Core_Layer.Models;
using Core_Layer.Repository;
using Microsoft.EntityFrameworkCore;
using Service_Layer.Interfaces.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer
{
   public class DiscountCodeRepository:CRUD<DiscountCode>, IDiscountCodeRepository
    {
        public DiscountCodeRepository(ApplicationDbContext context):base(context) { }
        public DiscountCode GetByName(string Name)
        {
            return Context.Set<DiscountCode>().FirstOrDefault(s => s.code == Name);
        }
    }
}
