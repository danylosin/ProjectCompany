using Microsoft.AspNetCore.Mvc;
using ProjectCompany.Services;
using ProjectCompany.Models;

namespace ProjectCompany.Controllers
{
    public class ContributionController : Controller
    {
        private ProjectService projectService;

        public ContributionController(AppContext appContext)
        {
            this.projectService = new ProjectService(appContext);
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
            ViewBag.project = this.projectService.GetProjectById(id);

            var m = contribution;
            
            return View();
        }
    }
}