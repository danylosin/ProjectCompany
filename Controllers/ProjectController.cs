﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectCompany.Services;
using ProjectCompany.Models;

namespace ProjectCompany.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private ProjectService projectService;

        public ProjectController(ProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet]
        public ActionResult<List<Project>> Index()
        {
            return this.projectService.GetAllProjects();
        }

        [HttpGet("{id:int:min(1)}")]
        public IActionResult Show(int id)
        {
            Project project = this.projectService.GetProjectById(id);
          
            if (project == null) {
                return new NotFoundResult();
            }
            
            return Ok(project);
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] Project project)
        {
            if (ModelState.IsValid) {
                this.projectService.AddProject(project);
                return Ok(project);
            } else {
                return UnprocessableEntity(ModelState);
            }
        }
        
        [HttpDelete("{id:int:min(1)}")]
        public IActionResult Delete(int id)
        {   
            Project project = this.projectService.GetProjectById(id);
            if (project == null) {
   
                return new NotFoundResult();
            }
            this.projectService.DeleteProject(project);

            return Ok();
        }

        //[HttpGet("project/recrute")]
        public IActionResult Recrute()
        {
            //ViewBag.project = this.projectService.GetProjectById(id);
            
            return View();
        }

        //[HttpPost("project/recrute")]
        public IActionResult Recrute(int id, List<Skill> skills)
        {
            // TODO
            return View();
        }
    }
}
