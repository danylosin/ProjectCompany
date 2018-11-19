using Microsoft.AspNetCore.Mvc;
using ProjectCompany.Services;

namespace ProjectCompany.Controllers
{
    public class ContributionController : Controller
    {
        private ProjectService projectService;

        public ContributionController(AppContext appContext)
        {
            this.projectService = new ProjectService(appContext);
        }

        [HttpGet("project/{id:int:min(1)}/contributions")]
        public IActionResult Index(int id)
        {
            ViewBag.project = this.projectService.GetProjectById(id);
            
            return View();
        }
        
        public IActionResult Create(int id)
        {

            return View();
        }
    }
}