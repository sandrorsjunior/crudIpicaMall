using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudIpcaMall.src.Models
{
    public class ResponseModel <T>
    {
        public T? Data {get; set;}
        public bool status {get;set;} = false;
        public string message {get; set;} = string.Empty;
    }
}