using Microsoft.AspNetCore.Mvc;
using ProjectCompany.Services;
using ProjectCompany.Models;

namespace ProjectCompany.Controllers
{
    public class ContributionController : Controller
    {
        private ProjectService projectService;
        private ContributionService contributionService;

        public ContributionController(ContributionService contributionService, ProjectService projectService)
        {
            this.projectService = projectService;
            this.contributionService = contributionService;
        }

        //[HttpGet("project/{id:int:min(1)}/contribution")]
        public IActionResult Index(int id)
        {
            ViewBag.project = this.projectService.GetProjectById(id);
            
            return View();
        }
        
        [HttpPost("api/project/{id:int:min(1)}/[controller]")]
        public IActionResult Create(int id, [FromBody] Contribution contribution)
        {
            if (ModelState.IsValid) {
                contribution.ProjectId = id;
                this.contributionService.AddContributon(contribution);
                return Ok(this.contributionService.GetContributionById(contribution.Id)); 
            }
            
            return UnprocessableEntity(ModelState);
        }

        [HttpPut("api/contribution/{id:int:min(1)}")]
        public IActionResult Put(int id, [FromBody] Contribution contribution) 
        {
            Contribution editingContribution = this.contributionService.GetContributionById(id);

            if (editingContribution == null) {
                return NotFound();
            }

            editingContribution.EmployeeId = contribution.EmployeeId;
            editingContribution.Title = contribution.Title;
            editingContribution.DatePeriod = contribution.DatePeriod;

            this.contributionService.UpdateContribution(editingContribution);

            return Ok(editingContribution);
        }

        [HttpDelete("api/contribution/{id:int:min(1)}")]
        public IActionResult Delete(int id) 
        {
            Contribution contribution = this.contributionService.GetContributionById(id);
            if (contribution == null) {
                return NotFound();
            }
            this.contributionService.RemoveContribution(contribution);

            return Ok();
        }
    }
}
