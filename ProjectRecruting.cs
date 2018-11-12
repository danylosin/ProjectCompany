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
        protected int limitOfEmployees;

        public ProjectRecruting(Project project, List<Skill> skills, List<Employee> employees, int limit)
        {
            this.project = project;
            this.skills = skills;
            this.allEmployees = employees;
            this.limitOfEmployees = limit;
        }

        public void Output()
        {
            Console.Write(this.project.Title + " needs next skills: ");
            foreach (Skill skill in this.skills) {
                Console.Write(skill.title + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Found next employees: ");
            foreach (ProjectCandidate projectCandidate in this.GetProjectCandidates()) {
                this.OutputInfoAboutProjectCandidate(projectCandidate);
            }
        }

        protected List<ProjectCandidate> GetProjectCandidates()
        {
             return this.allEmployees
                .Select((emp) => new ProjectCandidate(emp, this.CalculateEmployeeSkillCoverage(emp)))
                .OrderByDescending(ProjectCandidate => ProjectCandidate.skillCoverage)
                .Take(this.limitOfEmployees)
                .ToList();
        }

        private float CalculateEmployeeSkillCoverage(Employee employee)
         {
            int quanitityOfMatchedSkills = 0;
            foreach (Skill skill in this.skills) {
                if (employee.Skills.Contains(skill)) {
                    quanitityOfMatchedSkills++;
                }
            }
            
            return (float)quanitityOfMatchedSkills / skills.Count;
         }

        protected void OutputInfoAboutProjectCandidate(ProjectCandidate projectCandidate)
        {
            Employee employee = projectCandidate.employee;
            Console.Write(employee.Name + ". His skill coverage is " + projectCandidate.skillCoverage + ". He has next skills: ");
            foreach (Skill skill in employee.Skills) {
                Console.Write(skill.title + " ");
            }
            Console.WriteLine();
        }
    }
}
