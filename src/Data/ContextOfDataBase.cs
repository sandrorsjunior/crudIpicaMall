using CrudIpcaMall.src.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CrudIpcaMall.src.Data
{
    public class ContextOfDataBase : DbContext
    {
        public ContextOfDataBase(DbContextOptions<ContextOfDataBase> options) : base(options)
        {
        }

        public DbSet<UsersModel> users {get; set;}
        public DbSet<ProductsModel> products {get; set;}
        public DbSet<RegistersModel> register { get; set; }
        public DbSet<EncryptionsModel> encryptions { get; set; }
    }
}