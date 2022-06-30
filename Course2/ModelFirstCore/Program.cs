using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModelFirstCore.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ModelFirstCoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ModelFirstCoreContext") ?? throw new InvalidOperationException("Connection string 'ModelFirstCoreContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
