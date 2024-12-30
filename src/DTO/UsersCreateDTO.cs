using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudIpcaMall.src.Models;

namespace CrudIpcaMall.src.DTO
{
    public class UsersCreateDTO
    {
        public string Name {get; set;}
        public string Email {get; set;}
        public DateTime Birthday { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
    }
}