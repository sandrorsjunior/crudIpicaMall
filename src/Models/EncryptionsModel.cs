
namespace CrudIpcaMall.src.Models
{
    public class EncryptionsModel
    {
        public int Id {get;set;}
        public int UserId {get;set;}
        public string Password {get;set;}
        public byte[] Salt {get;set;}
        public UsersModel UsersModel {get;set;}
    }
}