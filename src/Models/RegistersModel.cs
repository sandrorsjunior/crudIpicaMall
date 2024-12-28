using System.Text.Json.Serialization;

namespace CrudIpcaMall.src.Models
{
    public class RegistersModel
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int UserId { get; set; }
        public string task { get; set; }
        [JsonIgnore]
        public ProductsModel? Products { get; set; }
        [JsonIgnore]
        public UsersModel Users { get; set; }
        public DateTime _dateCreation { get; set; }
    }
}
