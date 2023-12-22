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
        public Product UpdateProduct(Product product)
        {
            return _productdal.UpdateProduct(product);
        }
        public bool DeleteProduct(int Id)
        {
            return _productdal.DeleteProduct(Id);
        }
    }
}
