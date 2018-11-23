using Microsoft.AspNetCore.Mvc;
using ProjectCompany.Services;
using ProjectCompany.Models;

namespace ProjectCompany.Controllers
{
    [Route("api/project/{id:int:min(1)}/[controller]")]
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
        
        [HttpPost]
        public IActionResult Create(int id, [FromBody] Contribution contribution)
        {
            contribution.EmployeeId = 1;
            if (ModelState.IsValid) {
                contribution.ProjectId = id;
                this.contributionService.AddContributon(contribution);
                return Ok(this.contributionService.GetContributionById(contribution.Id)); 
            }
            
            return UnprocessableEntity(ModelState);
        }
    }
}
