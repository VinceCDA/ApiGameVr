using ApiGameVr.Application;
using ApiGameVr.Infrastructure;
using ApiGameVr.Infrastructure.Identity.Users;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAuthorization();
//builder.Services.AddIdentityApiEndpoints<IdentityAdminUser>()
//    .AddEntityFrameworkStores<AdminDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Replace with your frontend URL
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials(); // Only if using cookies/auth headers
    });
});
var app = builder.Build();
app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapSwagger("/openapi/{documentName}.json");
    app.MapScalarApiReference();
}
app.UseHttpsRedirection();
app.CustomMapIdentityApi<IdentityAdminUser>();

app.UseAuthorization();

app.MapControllers().RequireCors("AllowAll");

app.Run();
