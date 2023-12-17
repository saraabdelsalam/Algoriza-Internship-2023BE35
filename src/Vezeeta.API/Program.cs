using Vezeeta.API.Endpoints;
using Vezeeta.Application;
using Vezeeta.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterInfrastructureServices(builder.Configuration)
    .RegisterApplicationServices();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.MapAdminDashboardEndpoints()
    .MapDiscountCodeEndpoints()
    .MapDoctorSettingsEndpoints()
    .MapPatientSettingsEndpoints()
    .MapDoctorEndpoints()
    .MapPatientEndpoints();

app.Run();
