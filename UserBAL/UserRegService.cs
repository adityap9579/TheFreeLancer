using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDAL;
using UserModel;

namespace UserBAL
{
    public class UserRegService:IUserRegService
    {
        private readonly IUserRegRepo _userRepo;

        public UserRegService(IUserRegRepo userRepo)
        {
            _userRepo = userRepo;   
        }
       public User UserRegistration(User user)
        {
            return _userRepo.UserRegistration(user);
        }

       public  User GetUserById(int id)
        {
            return _userRepo.GetUserById(id);
        }

        public User UpdateUser(User user)
        {
            return _userRepo.UpdateUser(user);
        }

        public bool DeleteUserById(int id)
        {
            return _userRepo.DeleteUserById(id);
        }
        public UserLogin UserLogin(UserLogin user)
        {
            return _userRepo.UserLogin(user);
        }
    }
}
