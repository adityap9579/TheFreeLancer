using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserBAL;
using UserModel;

namespace UserApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBLL _productService;

        public ProductController(IProductBLL product)
        {
            _productService = product;
        }
        [HttpPost("AddProduct")]
        public Product AddProduct(Product product)
        {
            return _productService.AddProduct(product);
        }
        [HttpGet("GetProductBySearch")]
        public IList<Product> GetProductBySearch(string? text="")
        {
            return _productService.GetProductBySearch(text);
        }

        [HttpPut("UpdateProduct{Id}")]
        public Product UpdateProduct([FromRoute] int Id,[FromBody] Product product)
        {
            product.Id=Id;
            return _productService.UpdateProduct(product);
        }
        [HttpDelete("DeleteById")]
        public bool DeleteProduct(int Id)
        {
            return _productService.DeleteProduct(Id);
        }
    }
}
