using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudIpcaMall.src.Models
{
    public class UsersModel
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Email {get;set;}
        public DateTime Birthday { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public List<RegistersModel> userRegister { get; set; }
    }
}