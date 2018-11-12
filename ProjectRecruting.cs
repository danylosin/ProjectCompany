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
                Console.Write(skill.title);
            }
            Console.WriteLine();
            Console.WriteLine("Found next employees: ");
            foreach (Employee employee in this.GetSortedEmployeesByCompetensy()) {
                Console.Write(employee.Name);
                Console.Write(". He has next skills: ");
                foreach (Skill skill in employee.Skills) {
                    Console.Write(skill.title + " ");
                }
            }
        }

        protected List<Employee> GetSortedEmployeesByCompetensy()
        {
            var sortedEmployees = this.allEmployees.OrderBy(emp => emp.Competensy).ToList();

            return sortedEmployees;
        }

        protected void AssignCompetensyToAllEmployees()
        {
            foreach (Employee employee in this.allEmployees) {
                foreach (Skill skill in this.skills) {
                    this.calculateEmployeeCompetensy(employee);
                }
            }

        }

         protected float calculateEmployeeCompetensy(Employee employee)
         {
            int quanitityOfMatchedSkills = 0;
            foreach (Skill skill in this.skills) {
                if (employee.Skills.Contains(skill)) {
                    quanitityOfMatchedSkills++;
                }
            }
            int competensy = quanitityOfMatchedSkills / this.skills.Count;
            
            return competensy;
         }
    }
}
