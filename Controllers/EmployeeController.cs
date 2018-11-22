using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectCompany.Services;
using ProjectCompany.Models;
using ProjectCompany.ViewModels;


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
            EmployeeViewModel model = new EmployeeViewModel(this.skillService.GetAllSkills());

            return View(model);
        }

        [HttpPost("employee/create")]
        public IActionResult Create([Bind] EmployeeViewModel model)
        {
            if (ModelState.IsValid) {
                Employee employee = new Employee(model.Name);
                foreach (var skill in model.SelectedSkills) {
                    int j;
                    Int32.TryParse(skill, out j);
                    employee.EmployeeSkills.Add(new EmployeeSkill() {SkillId = j, Employee = employee});
                }
                this.employeeService.AddEmployee(employee);
            };

            return View(model);
        }

        [HttpPost("employee/createfromjson")]
        public IActionResult CreateFromJson([FromBody] Employee employee)
        {
            if (ModelState.IsValid) {
                this.employeeService.AddEmployee(employee);
                return Ok(employee);
            }
            return UnprocessableEntity(ModelState);
        }
    }
}
