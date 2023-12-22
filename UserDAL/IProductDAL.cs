using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModel;

namespace UserDAL
{
    public interface IProductDAL
    {
        Product AddProduct(Product product);

        IList<Product> GetProductBySearch(string text);

        Product UpdateProduct(Product product);
        bool DeleteProduct(int Id);
    }
}
