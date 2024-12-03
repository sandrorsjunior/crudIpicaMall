using CrudIpcaMall.src.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudIpcaMall.src.Data
{
    public class ContextOfDataBase : DbContext
    {
        public ContextOfDataBase(DbContextOptions<ContextOfDataBase> options) : base(options)
        {
        }

        public DbSet<UsersModel> users {get; set;}
        public DbSet<ProductsModel> products {get; set;}
    }
}