using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudIpcaMall.src.DTO;
using CrudIpcaMall.src.Models;

namespace CrudIpcaMall.src.Repository
{
    public interface ProductsInterface
    {
        public Task<ResponseModel<List<ProductsModel>>> ListAllProducts();
        public Task<ResponseModel<ProductsModel>> SearchProductById(int Id);
        public Task<ResponseModel<ProductsModel>> EditProduct(ProductEditDTO product);
        public Task<ResponseModel<ProductsModel>> CreateNewProduct(ProductCreateDTO product);
        public Task<ResponseModel<ProductsModel>> RemoveProduct(int Id);

    }
}