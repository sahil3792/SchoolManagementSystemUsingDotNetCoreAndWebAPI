using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementWebAPI.Repo;

namespace SchoolManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuardianController : ControllerBase
    {
        private readonly GuardianRepo repo;

        public GuardianController(GuardianRepo repo)
        {
            this.repo = repo;
        }

        [Route("GetFees/{id}")]
        [HttpGet]
        public IActionResult GetFeesPay(string id)
        {
            var data = repo.FessPayGet(id);
            if (data == null)
            {
                return null;
            }
            else
            {
                return Ok(data);
            }
        }
    }
}
