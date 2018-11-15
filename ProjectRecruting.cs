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
        protected CalculatingScoreStrategy scoreCalculator;
        protected List<Employee> allEmployees;
        protected int limitOfEmployees;

        public ProjectRecruting(Project project, CalculatingScoreStrategy scoreCalculator, List<Employee> employees, int limitOfEmployees)
        {
            this.project = project;
            this.scoreCalculator = scoreCalculator;
            this.allEmployees = employees;
            this.limitOfEmployees = limitOfEmployees;
        }

        public void Output()
        {
            Console.WriteLine(this.project.Title + " needs employees");
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
            var variable = this.scoreCalculator.calculateScore(emp);
            return new ProjectCandidate(emp, this.scoreCalculator.calculateScore(emp));
        }

        protected void OutputInfoAboutProjectCandidate(ProjectCandidate projectCandidate)
        {
            Employee employee = projectCandidate.Employee;
            Console.Write(employee.Name + ". His score is " + Math.Round(projectCandidate.Score, 2) + ". He has next skills: ");
            
            foreach (EmployeeSkill employeeSkill in employee.EmployeeSkills) {
                Console.Write(employeeSkill.Skill.Title + " ");
            }

            Console.WriteLine();
        }
    }
}
