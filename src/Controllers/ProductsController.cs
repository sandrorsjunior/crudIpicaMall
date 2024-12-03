using CrudIpcaMall.src.DTO;
using CrudIpcaMall.src.Models;
using CrudIpcaMall.src.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CrudIpcaMall.src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductsInterface _products;
        public ProductsController(ProductsInterface product){
            this._products = product;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<ProductsModel>>>> ListAllProducts(){
            var products = await this._products.ListAllProducts();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<ProductsModel>>> CreateNewProduct(ProductCreateDTO newProduct){
            var products = await this._products.CreateNewProduct(newProduct);
            return Ok(products);
        }
    }
}