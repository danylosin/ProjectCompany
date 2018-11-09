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
            Employee employee = new Employee("Employee");
            Report report = new Report();
            List<Skill> skills = new List<Skill>{
                new Skill("c#"),
                new Skill("angular")
            };
            employee.SetSkills(skills);
            Project project = new Project(
                "Super project", 
                new DatePeriod(new DateTime(2018, 6, 1), new DateTime(2018, 10, 11))
            );
            Contribution contribution = new Contribution("My Contribution", project);
            contribution.SetEmployee(employee);
            employee.AddContribution(contribution);
            project.AddContribution(contribution);
            report.Generate(employee);

            ProjectRecruting projectRecruting = new ProjectRecruting(project, skills);
            projectRecruting.Generate();
        }
    }
}
