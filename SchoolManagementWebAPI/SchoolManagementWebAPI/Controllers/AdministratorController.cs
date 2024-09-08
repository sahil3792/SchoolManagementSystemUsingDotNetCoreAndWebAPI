using Microsoft.AspNetCore.Mvc;
using SchoolManagementWebAPI.Models;
using SchoolManagementWebAPI.Repo;

namespace SchoolManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly AdministratorRepo repo;
        public AdministratorController(AdministratorRepo repo)
        {
            this.repo = repo;
        }

        
    }
}
