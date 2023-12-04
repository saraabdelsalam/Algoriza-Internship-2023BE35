using Core_Layer.Models;
using Core_Layer.Repository;
using Microsoft.AspNetCore.Identity;
using Repository_Layer;
using Service_Layer.Interfaces;
namespace Service_Layer.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        // dependancy injection applied here
        public ICRUD<DiscountCode> _discount { get; private set; }
        public ISpecializationRepo _specializationRepo { get; private set; }
        public IDoctorRepository _doctorRepository { get; private set; }
        public IAppUserRepository _userRepository { get; private set; }
       
        public UnitOfWork(ApplicationDbContext dbContext , UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _discount = new CRUD<DiscountCode>(_dbContext);
            _specializationRepo = new SpecializationRepo(_dbContext);
            _doctorRepository = new DoctorRepository(_dbContext, _userManager);
            _userRepository = new AppUserRepository(_dbContext, _userManager,_roleManager,_signInManager);

            
        }

  
        public Task SaveAsync() => _dbContext.SaveChangesAsync();

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
