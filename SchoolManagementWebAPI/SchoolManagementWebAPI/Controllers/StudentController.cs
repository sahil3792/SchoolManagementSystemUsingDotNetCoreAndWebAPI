using Microsoft.AspNetCore.Mvc;
using SchoolManagementWebAPI.Repo;

namespace SchoolManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentRepo repo;
        public StudentController(StudentRepo repo)
        {
            this.repo = repo;
        }
        

        [Route("FetchTimetableBasedOnStudentId/{id}")]
        [HttpGet]
        public IActionResult FetchTimetableBasedOnStudentId(string id)
        {
            var data =repo.FetchTimetableByStudentid(id);
            return Ok(data);
        }
    }
}
