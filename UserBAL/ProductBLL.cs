using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDAL;
using UserModel;

namespace UserBAL
{
    public class ProductBLL: IProductBLL
    {
        private readonly IProductDAL _productdal;

        public ProductBLL(IProductDAL product)
        {
            _productdal = product;
        }
        public Product AddProduct(Product product)
        {
            return _productdal.AddProduct(product);
        }

        public IList<Product> GetProductBySearch(string? text)
        {
            return _productdal.GetProductBySearch(text);
        }
    }
}
