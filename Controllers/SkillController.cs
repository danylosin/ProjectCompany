using Microsoft.AspNetCore.Mvc;
using ProjectCompany.Services;
using ProjectCompany.Models;

namespace ProjectCompany.Controllers
{
    [Route("api/[controller]")]
    public class SkillController : Controller
    {
        private SkillService skillService;

        public SkillController(SkillService skillService)
        {
            this.skillService = skillService;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {       
            return Ok(this.skillService.GetAllSkills());
        }
    }
}
