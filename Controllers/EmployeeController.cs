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
    public class EmployeeController : Controller
    {
        private EmployeeService employeeService;
        private SkillService skillService;

        public EmployeeController(AppContext appContext)
        {
            this.employeeService = new EmployeeService(appContext);
            this.skillService = new SkillService(appContext);
        }

        [HttpGet("/employee")]
        public IActionResult Index()
        {
            ViewBag.employees = this.employeeService.GetAllEmployees();

            return View();
        }

        [HttpGet("employee/{id:int:min(1)}")]
        public IActionResult Show(int id)
        {
            ViewBag.employee = this.employeeService.GetEmployeeById(id);
            
            return View();
        }

        [HttpGet("employee/create")]
        public IActionResult Create()
        {
            ViewBag.Skills = this.skillService.GetAllSkills();
            
            return View();
        }

        [HttpPost("employee/create")]
        public IActionResult Create(Employee employee)
        {
            this.employeeService.AddEmployee(employee);

            return Redirect("/employee/" + employee.Id);
        }
    }
}
