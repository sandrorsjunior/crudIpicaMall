using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace CrudIpcaMall.src.DTO
{
    public class ProductEditDTO 
    {
        public int Id {get;set;}
        public string? Name {get;set;}
        public int? Qtd {get;set;}
        public float? Value {get;set;}
    }
}