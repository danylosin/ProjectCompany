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

        [HttpPost()]
        public IActionResult Create([FromBody] EmployeeViewModel model)
        {
            if (ModelState.IsValid) {
                Employee employee = new Employee(model.Name);
                List<EmployeeSkill> employeeSkills = model.Skills
                            .Select(s => new EmployeeSkill()
                            {
                                SkillId = s.Id,
                                Employee = employee
                            })
                            .ToList(); 
                employee.EmployeeSkills = employeeSkills;
                this.employeeService.AddEmployee(employee);
                
                return Ok(employee);
            };

            return UnprocessableEntity(ModelState);
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
