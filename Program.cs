using System;
using ProjectCompany.Activity;
using ProjectCompany.Person;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectCompany.Services;
using ProjectCompany.Seeds;

namespace ProjectCompany
{
    class Program
    {

        static void Main(string[] args)
        {
            using(AppContext appContext = new AppContext()) {
                /* Initing services */
                EmployeeService employeeService = new EmployeeService(appContext);
                ProjectService projectService = new ProjectService(appContext);
                SkillService skillService = new SkillService(appContext);
                ContributionService contributionService = new ContributionService(appContext);

                /* End of initing services */

                ModelBuilderExtensions.Seed(appContext);
                
                Skill newSkill = new Skill("Amazing skill");
                Employee newEmployee = new Employee("Best employee");
                
                Project testProject = new Project("My first project1", new DatePeriod(new DateTime(2017, 01, 01), new DateTime(2017, 02, 01)));
                Contribution testContribution = new Contribution("My first contribution", 
                                    testProject, 
                                    newEmployee,
                                    new DatePeriod(new DateTime(2017, 01, 01), new DateTime(2017, 02, 01))
                                    );

                newEmployee.EmployeeSkills.Add(new EmployeeSkill() {Skill = newSkill, Employee = newEmployee});
                testContribution.ContributionSkills.Add(new ContributionSkill(){Skill = newSkill, Contribution = testContribution});


                skillService.AddSkill(newSkill);
                employeeService.AddEmployee(newEmployee);   
                

                /* Test adding */

                projectService.AddProject(testProject);
                contributionService.AddContributon(testContribution);

                //appContext.SaveChanges();
                

                /* Outputing data */

                Report report = new Report();  

                Employee employeeDan = employeeService.GetEmployeeById(1);
                Project project = projectService.GetProjectById(1); 

                report.OutputAboutEmployee(employeeDan);
                report.OutputAboutProject(project);

                report.OutputTopProjectsByCountOfContributions(projectService.GetProjectsByCountOfContributions(3));


                 
                List<Contribution> projectActivityByDatePeriod = projectService.GetProjectActivyByDatePeriod(
                                            project, 
                                            new DatePeriod(new DateTime(2017, 01, 01), new DateTime(2017, 05, 08))
                                        );  


                Console.WriteLine("Info about activity of " + project.Title + " in period");                        
                report.OutputProjectActityByDatePeriod(projectActivityByDatePeriod, new DatePeriod(new DateTime(2017, 01, 01), new DateTime(2017, 05, 08)));                        
                

                List<Contribution> ProjectContributionsByYear = projectService
                                    .GetProjectActivityByYear(
                                        project, 
                                        new DateTime(2017, 01, 01)
                                    );
                Console.WriteLine("Info about activity of " + project.Title + " in 2017");

                report.OutputProjectContributionsByYear(ProjectContributionsByYear, new DateTime(2017, 01, 01));    
                /* Executing ProjectRecruting */

                List<int> skillInts = new List<int>{ 1, 2, 3 };

                List<Skill> skills = appContext.skills.Where(s => skillInts.Contains(s.Id)).ToList();

                CalculateScoreBySkillCoverage calculateScoreBySkillCoverage = new CalculateScoreBySkillCoverage(skills);
                CalculateScoreBySkillQuantity calculateScoreBySkillQuantity = new CalculateScoreBySkillQuantity();
                
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
