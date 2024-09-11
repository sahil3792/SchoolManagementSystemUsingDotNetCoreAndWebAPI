using Microsoft.AspNetCore.Mvc;
using SchoolManagementWebAPI.Repo;

namespace SchoolManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly TeacherRepo repo;
        public TeacherController(TeacherRepo repo)
        {
            this.repo = repo;
        }
        [Route("FetchStudentByClassID/{id}")]
        [HttpPost]
        public IActionResult FetchStudentsByClassId(int id)
        {
            var data = repo.FetchAllStudentbyClassid(id);
            return Ok(data);
        }
    }
}
