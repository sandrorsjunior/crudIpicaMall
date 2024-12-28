using System.Text.Json.Serialization;
using CrudIpcaMall.src.Models;

namespace CrudIpcaMall.src.DTO
{
    public class RegisterDTO
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public ProductsModel? Products { get; set; }
        public UsersModel? Users { get; set; }
    }
}
