using Core_Layer.Models;
using Core_Layer.Repository;
using Repository_Layer;
using Service_Layer.Interfaces;
namespace Service_Layer.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;
        // dependancy injection applied here
        public ICRUD<DiscountCode> _discount { get; private set; } 
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _discount = new CRUD<DiscountCode>(_dbContext);
            
        }

  
        public Task SaveAsync() => _dbContext.SaveChangesAsync();

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
