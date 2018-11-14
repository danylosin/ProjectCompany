using System;
using ProjectCompany.Activity;
using ProjectCompany.Person;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProjectCompany
{
    class Program
    {

        static void Main(string[] args)
        {
            using(AppContext appContext = new AppContext()) {
                Report report = new Report();

                Employee employeeDan = appContext
                        .employees
                        .Include(e => e.Contributions)
                        .ThenInclude(c => c.Project)
                        .Include(e => e.Contributions)
                        .ThenInclude(c => c.ContributionSkills)
                        .ThenInclude(cs => cs.Skill)
                        .First();
                Project project = appContext
                        .projects
                        .Include(p => p.Contributions)
                        .ThenInclude(c => c.ContributionSkills)
                        .ThenInclude(cs => cs.Skill)
                        .Include(p => p.Contributions)
                        .ThenInclude(c => c.Employee)
                        .First();               
                report.OutputAboutEmployee(employeeDan);
                report.OutputAboutProject(project);

                List<int> skillInts = new List<int>{ 1, 2, 3 };

                List<Skill> skills = appContext.skills.Where(s => skillInts.Contains(s.Id)).ToList();
                CalculateScoreBySkillCoverage calculateScoreBySkillCoverage = new CalculateScoreBySkillCoverage(skills);

                Console.WriteLine(project.Title + " needs employees");
                calculateScoreBySkillCoverage.OutputNeededSkills();    
                ProjectRecruting projectRecruting = new ProjectRecruting(
                    project, 
                    calculateScoreBySkillCoverage, 
                    appContext.employees.Include(e => e.EmployeeSkills)
                        .ThenInclude(es => es.Skill)
                        .ToList(), 
                    3
                );
                projectRecruting.Output();
            };
        }
    }
}
