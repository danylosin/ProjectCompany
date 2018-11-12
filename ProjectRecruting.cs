using ProjectCompany.Activity;
using ProjectCompany.Person;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ProjectCompany
{
    public class ProjectRecruting
    {
        protected Project project;
        protected List<Skill> skills;
        protected List<Employee> allEmployees;

        public ProjectRecruting(Project project, List<Skill> skills, List<Employee> employees)
        {
            this.project = project;
            this.skills = skills;
            this.allEmployees = employees;
        }

        public void Output()
        {
            Console.Write(this.project.Title + " needs next skills: ");
            foreach (Skill skill in this.skills) {
                Console.Write(skill.title + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Found next employees: ");
            foreach (Employee employee in this.GetSortedEmployeesByCompetensy()) {
                this.OutputInfoAboutEmployee(employee);
            }
        }

        protected List<Employee> GetSortedEmployeesByCompetensy()
        {
            this.AssignCompetensyToAllEmployees();

            return this.allEmployees.OrderByDescending(emp => emp.Competensy).ToList();
        }

        protected void AssignCompetensyToAllEmployees()
        {
            foreach (Employee employee in this.allEmployees) {
                employee.CalculateEmployeeCompetensy(this.skills);
            }
        }

        protected void OutputInfoAboutEmployee(Employee employee)
        {
            Console.Write(employee.Name + ". His competensy is " + employee.Competensy + ". He has next skills: ");
            foreach (Skill skill in employee.Skills) {
                Console.Write(skill.title + " ");
            }
            Console.WriteLine();
        }
    }
}
