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
            //
            return Ok(this.skillService.GetAllSkills());
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] Skill skill)
        {
            if (ModelState.IsValid) {
                this.skillService.AddSkill(skill);
                return Ok(skill);
            }

            return UnprocessableEntity(ModelState);
        }
    }
}
