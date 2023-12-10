using AutoMapper;
using Core_Layer.Models;
using Core_Layer.Repository;
using Core_Layer.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Repository_Layer;
using Service_Layer;
using Service_Layer.Interfaces;
using Service_Layer.Interfaces.Admin;
using Service_Layer.Services;
using Service_Layer.Services.Admin;
using vezeeta;

var builder = WebApplication.CreateBuilder(args);
// Add DbContext with dependency injection

builder.Services.AddDbContext<ApplicationDbContext>(
             opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                 b => b.MigrationsAssembly("Repository Layer")));

// dependency injection for services
builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
builder.Services.AddTransient<IDiscountCode,DiscountCodeServices>();
builder.Services.AddTransient<IAppUserServices, AppUserServices>();
builder.Services.AddTransient<ISpecializationRepo, SpecializationRepo>();
builder.Services.AddTransient<IDoctorServices, DoctorServices>();
builder.Services.AddTransient<IPatientServices, PatientServices>();
builder.Services.AddTransient<IAppointmentServices, AppointmentServices>();
builder.Services.AddTransient<ITimesServices, TimesServices>(); 
builder.Services.AddTransient<IRequestServices, RequestServices>();
builder.Services.AddTransient<IEmailSender,EmailSenderService>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();


// inject auto mapper
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<MappingProfiles>();
});
IMapper _mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(_mapper);

//builder.Services.AddSingleton(_mapper);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



    var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



#region 
//using (var scope = app.Services.CreateScope())
//{
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//    var roles = new[] { "Admin", "Doctor", "Patient" };
//    foreach(var role in roles)
//    {
//        if (!await roleManager.RoleExistsAsync(role))
//            await roleManager.CreateAsync(new IdentityRole(role));
//    }


//}
//using (var scope = app.Services.CreateScope())
//{
//    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
//    string email = "Admin@vezeeta.com";
//    string password = "Admin123";
//    if(await userManager.FindByEmailAsync(email) == null)
//    {
//        var user = new ApplicationUser();
//        user.Email = email;
//        user.UserName = email;
//        await userManager.CreateAsync(user, password);
//        await userManager.AddToRoleAsync(user, "Admin");
//    }
//}
#endregion
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

