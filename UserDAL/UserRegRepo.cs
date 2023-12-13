using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModel;

namespace UserDAL
{
    public class UserRegRepo : IUserRegRepo
    {
        private readonly string _connectionString;
        public UserRegRepo(string connectionString)
        {
            _connectionString = connectionString;
        }
        public User UserRegistration(User user)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpsertUserReg", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tempId", user.Id);
                cmd.Parameters.AddWithValue("@Name", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@Nationality", user.Nationality);
                cmd.Parameters.AddWithValue("@MobileNo", user.MobileNo);


                SqlParameter outputparam = cmd.Parameters.Add("@Id", SqlDbType.Int);
                outputparam.Direction = ParameterDirection.Output;

                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (user.Id == 0)
                {
                    user.Id = (int)outputparam.Value;
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
            return user;
        }
        public User UpdateUser(User user)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpsertUserReg", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tempId", user.Id);
                cmd.Parameters.AddWithValue("@Name", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@Nationality", user.Nationality);
                cmd.Parameters.AddWithValue("@MobileNo", user.MobileNo);
                cmd.Parameters.AddWithValue("@Id", user.Id);

                con.Open();
                int i = cmd.ExecuteNonQuery();

                if (i > 0)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Fail");
                }
            }
            return user;

        }

        public User GetUserById(int id)
        {

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                User user = new User();
                SqlCommand cmd = new SqlCommand("select * from [User] where Id=@id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    user = new User()
                    {
                        Id = rdr.GetInt32("id"),
                        FirstName = rdr.GetString("firstName"),
                        LastName = rdr.GetString("lastName"),
                        Email = rdr.GetString("email"),
                        Address = rdr.GetString("address"),
                        Nationality = rdr.GetString("nationality"),
                        MobileNo = rdr.GetString("mobileNo")
                    };
                }
                return user;
            }
        }
        public bool DeleteUserById(int id)
        {

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM [User] WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
                con.Close();    
                return i>0;
            }
        }
        public UserLogin UserLogin(UserLogin user)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UserLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@password", user.Password);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    user = new UserLogin()
                    {
                        Email= rdr.GetString("email"),
                        Password= rdr.GetString("password")
                    };
                }
            }
            return user;
        }

    }
}
