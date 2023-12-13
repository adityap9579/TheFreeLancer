using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModel;

namespace UserDAL
{
    public class ProductDAL: IProductDAL
    {
        private readonly string _connectionString;
        public ProductDAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Product AddProduct(Product product)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddProduct", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tempId", product.Id);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Domain", product.Domain);
                cmd.Parameters.AddWithValue("@Price", product.Price);

                SqlParameter outputparam = cmd.Parameters.Add("@Id", SqlDbType.Int);
                outputparam.Direction = ParameterDirection.Output;

                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (product.Id == 0)
                {
                    product.Id = (int)outputparam.Value;
                }

                if (i > 0)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Fail");
                }
            }
            return product;
        }

        public IList<Product> GetProductBySearch(string? text)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                List<Product> productlist = new List<Product>();
                SqlCommand cmd = new SqlCommand("GetProductBySearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@text", text);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var product = new Product()
                    {
                        Id = rdr.GetInt32("id"),
                        Name = rdr.GetString("name"),
                        Domain = rdr.GetString("domain"),
                        Price = (float)rdr.GetDouble("price")
                    };
                    productlist.Add(product);

                }
                return productlist;                
            }     
          
        }
        
    }

}
