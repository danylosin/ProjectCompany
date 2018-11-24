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
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private EmployeeService employeeService;
        private SkillService skillService;

        public EmployeeController(ApplicationContext appContext)
        {
            this.employeeService = new EmployeeService(appContext);
            this.skillService = new SkillService(appContext);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(this.employeeService.GetAllEmployees());
        }

        [HttpGet("{id:int:min(1)}")]
        public IActionResult Show(int id)
        {
            
            return Ok(this.employeeService.GetEmployeeById(id));
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
