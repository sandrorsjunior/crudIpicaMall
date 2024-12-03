using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudIpcaMall.src.Models
{
    public class ProductsModel
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public int Qtd {get;set;}
        public float Value {get;set;}
    }
}