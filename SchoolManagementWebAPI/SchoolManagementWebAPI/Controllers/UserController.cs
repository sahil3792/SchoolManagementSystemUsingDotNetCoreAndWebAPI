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

        [Route("AddAdministrator")]
        [HttpPost]
        public IActionResult AddAdministrator(Administrator administrator)
        {
            var data = repo.AddAdministrator(administrator);
            string Urole = "Administrator";
            repo.AddUser(data.AdministratorUserId, data.Password, Urole);
            return Ok("Administrator Added Successfully");
        }

        [Route("AddSubject")]
        [HttpPost]
        public IActionResult AddSubjects(Subject sub)
        {
            repo.AddSubjects(sub);
            return Ok("Subject Add Successfully");
        }

        [Route("FetchAllSubjects")]
        [HttpGet]
        public IActionResult FetchAllSubjects()
        {
            var data = repo.GetSubjects();
            return Ok(data);
        }

        [Route("AddTeacher")]
        [HttpPost]
        public IActionResult AddTeacher(Teacher teacher)
        {
            repo.AddTeacher(teacher);
            return Ok("Teacher Added Successfully");
        }

    }
}
