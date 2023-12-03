using Core_Layer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository_Layer;
using Service_Layer.Interfaces;
using Service_Layer.Interfaces.Admin;
using Service_Layer.Services;
using Service_Layer.Services.Admin;
using vezeeta;

var builder = WebApplication.CreateBuilder(args);
// Add DbContext with dependency injection


// register usermanger & rolemanager ==>userstore &rolestore
//builder.Services.AddScoped<ILoggerManager, LoggerManager>();


builder.Services.AddDbContext<ApplicationDbContext>(
             opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                 b => b.MigrationsAssembly("Repository Layer")));


builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
builder.Services.AddTransient<IDiscountCode,DiscountCodeServices>();
//builder.Services.ConfigureUnitOfWork();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

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

app.UseHttpsRedirection();
app.MapControllers();


app.Run();

