using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserModel
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }=string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
    }

    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
        //public string token { get; set; }
    }
}
