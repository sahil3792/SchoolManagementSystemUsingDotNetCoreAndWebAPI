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

        [Route("GetAllTeachers")]
        [HttpGet]
        public IActionResult GetAllTeacher()
        {
            var data = repo.GetAllTeachers();
            return Ok(data); 
        }

        [Route("AddGuardian")]
        [HttpPost]
        public IActionResult AddGuardian(Guardian g)
        {
            repo.AddGuardian(g);
            return Ok("Guardian Added Successfully");
        }

        [Route("FetchAllGuardians")]
        [HttpGet]
        public IActionResult FetchAllGuardian()
        {
            var data = repo.GetAllGuardian();
            return Ok(data);
        }

        [Route("FetchAllClasses")]
        [HttpGet]
        public IActionResult FetchAllClasses()
        {
            var data = repo.GetAllClass();
            return Ok(data);
        }

        [Route("AddClass")]
        [HttpPost]
        public IActionResult AddClass(Class c)
        {
            repo.AddClass(c);
            return Ok("Class Added Successfully");
        }

        [Route("AddStudent")]
        [HttpPost]
        public IActionResult AddStudent(Student s)
        {
            repo.AddStudent(s);
            return Ok();
        }

        [Route("AddTimetable")]
        [HttpPost]
        public IActionResult AddTimetable(Timetable tt)
        {
            repo.AddTimetable(tt);
            return Ok("Timetable added successfully");
        }
    }
}
