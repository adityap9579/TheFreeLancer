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
    }
}
