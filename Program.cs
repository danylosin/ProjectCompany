using System;
using ProjectCompany.Activity;
using ProjectCompany.Person;
using System.Collections.Generic;
namespace ProjectCompany
{
    class Program
    {

        static void Main(string[] args)
        {
            Skill skill1 = new Skill("c#");
            Skill skill2 = new Skill("angular");

            Employee employee = new Employee("Bob");
            Report report = new Report();

            employee.AddSkill(skill1);
        
            Project project = new Project(
                "ProjectCompany", 
                new DatePeriod(new DateTime(2018, 6, 1), new DateTime(2018, 10, 11))
            );

            Contribution contribution = new Contribution(
                "Writing backend", 
                project,
                new DatePeriod(new DateTime(2018, 6, 1), new DateTime(2018, 10, 11))
            );

            contribution.AddSkill(skill1);
            contribution.SetEmployee(employee);

            employee.AddContribution(contribution);

            project.AddContribution(contribution);
            
            report.OutputAboutEmployee(employee);

            Console.WriteLine("_____________");

            report.OutputAboutProject(project);

            ProjectRecruting projectRecruting = new ProjectRecruting(
                project, 
                new List<Skill>(){
                    skill2
                }, 
                new List<Employee>(){employee});
            Console.WriteLine("_____________");
            projectRecruting.Output();
        }
    }
}
