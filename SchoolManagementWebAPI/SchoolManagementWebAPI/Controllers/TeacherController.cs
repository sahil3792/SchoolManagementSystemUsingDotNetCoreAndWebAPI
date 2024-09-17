using Microsoft.AspNetCore.Mvc;
using SchoolManagementWebAPI.Models;
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
        [HttpGet]
        public IActionResult FetchStudentsByClassId(string id)
        {
            var data = repo.FetchAllStudentbyClassid(id);
            return Ok(data);
        }

        [Route("FetchTeachersLeavesBasedOnTeacherId/{id}")]
        [HttpGet]
        public IActionResult FetchTeachersLeavesBasedOnTeacherId(string id)
        {
            var data=repo.FetchAllTeacherLeavesBasedOnTeacherId(id).AsEnumerable();
            return Ok(data);
        }

        [Route("AddTeacherLeave")]
        [HttpPost]
        public IActionResult AddTeacherLeave(TeacherLeave tl)
        {
            repo.AddTeacherLeave(tl);
            return Ok("Successfully added leave");
        }

        [Route("AddStudentAttendance")]
        [HttpPost]
        public IActionResult AddStudentAttendance(string[] attendancelist)
        {
            repo.AddStudentAttendance(attendancelist);
            return Ok();
        }

        [Route("FetchAllSubjectsByStudentid/{id}")]
        [HttpGet]
        public IActionResult FetchAllSubjectsByStudentID(string id)
        {
            var data = repo.FetchAllSubjectByStudentid(id);
            return Ok(data);
        }
    }
}
