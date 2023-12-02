using Repository_Layer;
using Service_Layer.Interfaces;
using Service_Layer.Interfaces.Admin;
using Service_Layer.Services.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class UnitOfWork: IUnitOfWork
    {
        private ApplicationDbContext _dbContext;
        private IDiscountCode _discount;
        public UnitOfWork(ApplicationDbContext dbContext, IDiscountCode discount)
        {
            _dbContext = dbContext;
            _discount = discount;
        }

        
       
        public IDiscountCode discountCode
        {

            get {
                if(_discount is null)
                    _discount = new DiscountCodeRepo(_dbContext);
                return _discount; }
        }


        public Task SaveAsync() => _dbContext.SaveChangesAsync();
    }
}
