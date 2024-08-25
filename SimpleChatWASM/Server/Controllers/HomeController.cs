using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SimpleChatWASM.Shared.API;
using SimpleChatWASM.Shared.Entities;
using SimpleChatWASM.Shared.Repositories;

namespace SimpleChatWASM.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        
        
        public HomeController(IUserRepository userRepository)
        {
            
        }
        

        


    }
}
