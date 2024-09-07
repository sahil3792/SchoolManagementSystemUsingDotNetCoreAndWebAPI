using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SchoolManagementWebAPI.Models;
using SchoolManagementWebAPI.Repo;

namespace SchoolManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepo repo;
        public UserController(UserRepo repo)
        {
            this.repo = repo;
        }
        [Route("GetAllEmps")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            var data = repo.GetAllUser();
            return Ok(data);
        }

        [Route("AuthUser")]
        [HttpPost]
        public IActionResult AuthUser(User u)
        {
            var data = repo.AuthUser(u);
            if(data == null)
            {
                return Ok("Invalid Credentials");
            }
            else
            {
                
                return Ok(data);
            }
            
        }
        
    }
}
