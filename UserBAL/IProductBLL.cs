using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDAL;
using UserModel;

namespace UserBAL
{
    public interface IProductBLL
    {
        public Product AddProduct(Product product);

        public IList<Product> GetProductBySearch(string? text);
        public Product UpdateProduct(Product product);
        public bool DeleteProduct(int Id);
    }
}
