using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectCompany.Services;
using ProjectCompany.Models;

namespace ProjectCompany.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectService projectService;

        public ProjectController(AppContext appContext)
        {
            this.projectService = new ProjectService(appContext);
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            ViewBag.projects = this.projectService.GetAllProjects();

            return View();
        }

        [HttpGet("project/{id:int:min(1)}")]
        public IActionResult Show(int id)
        {
            ViewBag.project = this.projectService.GetProjectById(id);
            
            return View();
        }

        [HttpGet("project/recrute")]
        public IActionResult Recrute()
        {
            //ViewBag.project = this.projectService.GetProjectById(id);
            
            return View();
        }

        [HttpPost("project/recrute")]
        public IActionResult Recrute(int id, List<Skill> skills)
        {
            // TODO
            return View();
        }
    }
}
