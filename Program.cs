using CrudIpcaMall.src.Data;
using CrudIpcaMall.src.Models;
using CrudIpcaMall.src.Repository;
using CrudIpcaMall.src.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UsersInterface, UserService>();
builder.Services.AddScoped<ProductsInterface, ProductService>();

builder.Services.AddDbContext<ContextOfDataBase>(option => 
        option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
