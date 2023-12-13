using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModel;

namespace UserBAL
{
    public interface IUserRegService
    {
        User UserRegistration(User user);
        User GetUserById(int id);
        User UpdateUser(User user);
         bool DeleteUserById(int id);
        UserLogin UserLogin(UserLogin user);
    }
}
