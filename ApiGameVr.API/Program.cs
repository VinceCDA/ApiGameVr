using ApiGameVr.Application;
using ApiGameVr.Infrastructure;
using ApiGameVr.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAuthorization();
//builder.Services.AddIdentityApiEndpoints<IdentityAdminUser>()
//    .AddEntityFrameworkStores<AdminUserDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapSwagger("/openapi/{documentName}.json");
    app.MapScalarApiReference();
}
app.UseHttpsRedirection();
//app.CustomMapIdentityApi<IdentityAdminUser>();
app.UseAuthorization();

app.MapControllers();

app.Run();
