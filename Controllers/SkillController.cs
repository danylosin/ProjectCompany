using Microsoft.AspNetCore.Mvc;
using ProjectCompany.Services;
using ProjectCompany.Models;
using System.Collections.Generic;

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
            if (ModelState.IsValid && !this.skillService.isUniqueSkillTitle(skill)) {
                this.skillService.AddSkill(skill);
                return Ok(skill);
            }

            if (this.skillService.isUniqueSkillTitle(skill)) {
                ModelState.AddModelError("Skill", "Enter the unique skill");
            }
            return UnprocessableEntity(ModelState);
        }

        [HttpDelete("{id:int:min(1)}")]
        public IActionResult Delete(int id) {
            Skill skill = this.skillService.GetSkillById(id);
            if (skill == null) {
                return NotFound();
            }
            this.skillService.DeleteSkill(skill);

            return Ok();
        }
    }
}
