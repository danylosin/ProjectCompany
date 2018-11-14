using System;
using ProjectCompany.Activity;
using ProjectCompany.Person;
using System.Collections.Generic;
using System.Linq;
namespace ProjectCompany
{
    class Program
    {

        static void Main(string[] args)
        {
            using(AppContext appContext = new AppContext()) {
                 Project project = new Project("TEST PROJECT");
                 Contribution contribution = new Contribution("TEST CONTRIBUTION", project);
                 appContext.projects.Add(project);
                 appContext.contributions.Add(contribution);
                 appContext.SaveChanges();
                 Console.WriteLine(appContext.projects.Find(10).Contributions.First().Id);
            }
            /* 
            Skill skillCSharp = new Skill("c#");
            Skill skillAngular = new Skill("Angular");
            Skill skillReact = new Skill("React");
            Employee employeeBob = new Employee("Bob");
            Employee employeeDavid = new Employee("David");
            Employee employeeMike = new Employee("Mike");

            employeeBob.AddSkill(skillCSharp);
            employeeDavid.AddSkill(skillCSharp);
            employeeDavid.AddSkill(skillAngular);
            employeeMike.AddSkill(skillReact);
            */
            /* 
            Report report = new Report();

            DatePeriod datePeriod = new DatePeriod(new DateTime(2018, 6, 1), new DateTime(2018, 10, 11));

            Project project = new Project(
                "ProjectCompany", 
                datePeriod
            );

            Contribution contribution = new Contribution(
                "Writing backend", 
                project,
                datePeriod
            );
            Contribution otherContribution = new Contribution(
                "Writing frontend",
                project,
                datePeriod
            );
            contribution.AddSkill(skillCSharp);
            contribution.Employee = employeeBob;

            employeeBob.AddContribution(contribution);

            project.AddContribution(contribution);
            
            ProjectRecruting projectRecruting = new ProjectRecruting(
                project, 
                new List<Skill>(){
                    skillAngular,
                    skillCSharp,
                    skillReact
                }, 
                new List<Employee>(){
                    employeeBob, 
                    employeeDavid,
                    employeeMike
                }, 
                3
            );
            report.OutputAboutEmployee(employeeBob);

            report.OutputAboutProject(project);

            projectRecruting.Output();
            */
        }
    }
}
