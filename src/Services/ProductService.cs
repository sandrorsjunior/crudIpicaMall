using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudIpcaMall.src.Data;
using CrudIpcaMall.src.DTO;
using CrudIpcaMall.src.Models;
using CrudIpcaMall.src.Repository;
using Microsoft.EntityFrameworkCore;

namespace CrudIpcaMall.src.Services
{
    public class ProductService : ProductsInterface
    {
        private readonly ContextOfDataBase _context;
        public ProductService(ContextOfDataBase ctx){
            this._context = ctx;
        }

        public async Task<ResponseModel<List<ProductsModel>>> ListAllProducts()
        {
            ResponseModel<List<ProductsModel>> response = new ResponseModel<List<ProductsModel>>();
            
            try{
                var products = await this._context.products.ToListAsync();
                response.Data = products;
                response.status = true;
                response.message = "All products were collected";
                return response;
            }
            catch(Exception ex){
                Console.WriteLine($"There was something issue!\n {ex.Message}");
                response.status = false;
                response.message = "There was something issue!";
                return response;
            }

        }

        public async Task<ResponseModel<ProductsModel>> SearchProductById(int Id)
        {
            ResponseModel<ProductsModel> response = new ResponseModel<ProductsModel>();
            
            try{
                var product = await this._context.products.FirstOrDefaultAsync((product)=> product.Id == Id);
                if(product==null)
                {
                    response.status = true;
                    response.message = "Product not found!";
                    return response;
                }
                response.Data = product;
                response.status = true;
                response.message = "Product Found";
                return response;
            
            }
            catch(Exception ex){
                Console.WriteLine($"There was something issue!\n {ex.Message}");
                response.status = false;
                response.message = "There was something issue!";
                return response;
            }
        }

        public async Task<ResponseModel<ProductsModel>> EditProduct(ProductEditDTO  productEdit)
        {
            ResponseModel<ProductsModel> response = new ResponseModel<ProductsModel>();
            
            try{
                var product = await this._context.products.FirstOrDefaultAsync((product)=> product.Id == productEdit.Id);
                if(product==null)
                {
                    response.status = true;
                    response.message = "Product not found!";
                    return response;
                }
                product.Name = productEdit.Name ?? product.Name;
                product.Qtd = productEdit.Qtd ?? product.Qtd;
                product.Value = productEdit.Value ?? product.Value;
                
                this._context.Update(product);
                await _context.SaveChangesAsync();
                
                response.Data = product;
                response.status = true;
                response.message = "Product Found";
                return response;
            }
            catch(Exception ex){
                Console.WriteLine($"There was something issue!\n {ex.Message}");
                response.status = false;
                response.message = "Product not found!";
                return response;
            }
        }

        public Task<ResponseModel<ProductsModel>> RemoveProduct(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<ProductsModel>> CreateNewProduct(ProductCreateDTO product)
        {
            ResponseModel<ProductsModel> response = new ResponseModel<ProductsModel>();
            var newProduct = new ProductsModel();

            try
            {
                newProduct.Name = product.Name;
                newProduct.Qtd = product.Qtd;
                newProduct.Value = product.Value;

                this._context.Add(newProduct);
                this._context.SaveChanges();

                response.Data = newProduct;
                response.status = true;
                response.message = "Product created";
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was something issue!\n {ex.Message}");
                response.status = false;
                response.message = "Product not found!";
                return response;
            }

            

        }
    }
}