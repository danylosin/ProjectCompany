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

        public ProjectRecruting(Project project, List<Skill> skills, List<Employee> employees, int limitOfEmployees)
        {
            this.project = project;
            this.skills = skills;
            this.allEmployees = employees;
            this.limitOfEmployees = limitOfEmployees;
        }

        public void Output()
        {
            Console.Write(this.project.Title + " needs next skills: ");

            foreach (Skill skill in this.skills) {
                Console.Write(skill.Title + " ");
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
                .Select(this.GetProjectCandidate)
                .OrderByDescending(ProjectCandidate => ProjectCandidate.Score)
                .Take(this.limitOfEmployees)
                .ToList();
        }

        protected ProjectCandidate GetProjectCandidate(Employee emp)
        {
            return new ProjectCandidate(emp, this.CalculateEmployeeSkillCoverage(emp));
        }

        protected float CalculateEmployeeSkillCoverage(Employee employee)
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
            Employee employee = projectCandidate.Employee;
            Console.Write(employee.Name + ". His skill coverage is " + Math.Round(projectCandidate.Score, 2) + ". He has next skills: ");
            
            foreach (Skill skill in employee.Skills) {
                Console.Write(skill.Title + " ");
            }

            Console.WriteLine();
        }
    }
}
