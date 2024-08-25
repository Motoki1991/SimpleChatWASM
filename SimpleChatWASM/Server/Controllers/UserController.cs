using Microsoft.AspNetCore.Mvc;
using SimpleChatWASM.Shared.API;
using SimpleChatWASM.Shared.Entities;
using SimpleChatWASM.Shared.Repositories;

namespace SimpleChatWASM.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("getuser_byid")]
        public ApiResponse<UserEntity> GetUserById(string user_id)
        {
            var result = new ApiResponse<UserEntity>();
            try
            {
                result.data = _userRepository.GetById(user_id);
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return result;
        }
        [HttpGet("get_alluser")]
        public ApiResponse<List<UserEntity>> GetAllUsers()
        {
            var result = new ApiResponse<List<UserEntity>>();
            try
            {
                result.data = _userRepository.GetAllUsers();
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
            }
            return result;
        }
    }
}
