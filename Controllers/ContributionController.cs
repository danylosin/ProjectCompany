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

        [HttpGet("project/{id:int:min(1)}/contribution")]
        public IActionResult Index(int id)
        {
            ViewBag.project = this.projectService.GetProjectById(id);
            
            return View();
        }
        
        [HttpGet("project/{id:int:min(1)}/contribution/create")]
        public IActionResult Create(int id)
        {
            ViewBag.project = this.projectService.GetProjectById(id);

            return View();
        }

        [HttpPost("project/{id:int:min(1)}/contribution/create")]
        public IActionResult Create(int id, [Bind] Contribution contribution)
        {
            if (ModelState.IsValid) {
                contribution.ProjectId = id;
                this.contributionService.AddContributon(contribution); 
            }
            
            return View(contribution);
        }
    }
}
