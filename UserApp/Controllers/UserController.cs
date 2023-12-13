using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserBAL;
using UserModel;

namespace UserApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRegService _userRegService;

        public UserController(IUserRegService userRegService)
        {
            _userRegService = userRegService;
        }
        [HttpPost("UserReg")]
        public User UserRegistration(User user)
        {
            return _userRegService.UserRegistration(user);
        }
        [HttpGet("GetUserById")]   
        public User GetUserById(int id)
        {
            return _userRegService.GetUserById(id);
        }
        [HttpPut("UpdateUser/{id}")]
        public User UpdateUser([FromBody] User user, [FromRoute] int id)
        {
            user.Id = id;
            return _userRegService.UpdateUser(user);
        }
        [HttpDelete("DeleteUserById")]
        public bool DeleteUserById(int id)
        {
            return _userRegService.DeleteUserById(id);
        }
        [HttpPost("UserLogin")]
        public UserLogin UserLogin(UserLogin user)
        {
            return _userRegService.UserLogin(user);
        }
    }
}
