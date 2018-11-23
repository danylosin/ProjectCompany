using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;
using ProjectCompany;
using System.Linq;
using System.Collections.Generic;
using ProjectCompany.Models;

namespace ProjectCompany.Services
{
    public class EmployeeService
    {
        protected ApplicationContext appContext;
        public EmployeeService(ApplicationContext appContext)
        {
            this.appContext = appContext;
        }

        public Employee GetEmployeeById(int id)
        {
            return appContext.employees
                    .Include(e => e.Contributions)
                    .ThenInclude(c => c.Project)
                    .Include(e => e.Contributions)
                    .ThenInclude(c => c.ContributionSkills)
                    .ThenInclude(cs => cs.Skill)
                    .Include(e => e.EmployeeSkills)
                    .ThenInclude(es => es.Skill)
                    .Where(e => e.Id == id)
                    .First();
        }

        public List<Employee> GetAllEmployees()
        {
            return appContext.employees.Include(e => e.Contributions)
                    .ThenInclude(c => c.Project)
                    .Include(e => e.Contributions)
                    .ThenInclude(c => c.ContributionSkills)
                    .ThenInclude(cs => cs.Skill)
                    .Include(e => e.EmployeeSkills)
                    .ThenInclude(es => es.Skill)
                    .ToList();
        }

        public void AddEmployee(Employee employee)
        {

            this.appContext.employees.Add(employee);
            this.appContext.SaveChanges();
        }

        public void UpdateEmployee(Employee editedEmployee)
        {
          this.appContext.employees.Update(editedEmployee);
          this.appContext.SaveChanges();
        }

        public void RemoveEmployee(Employee employee)
        {
            this.appContext.employees.Remove(employee);
            this.appContext.SaveChanges();
        }
    }
}
