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
            Skill skillCSharp = new Skill("c#");
            Skill skillAngular = new Skill("angular");

            Employee employeeBob = new Employee("Bob");
            Employee employeeDavid = new Employee("David");

            Report report = new Report();

            employeeBob.AddSkill(skillCSharp);

            employeeDavid.AddSkill(skillCSharp);
            employeeDavid.AddSkill(skillAngular);

            Project project = new Project(
                "ProjectCompany", 
                new DatePeriod(new DateTime(2018, 6, 1), new DateTime(2018, 10, 11))
            );

            Contribution contribution = new Contribution(
                "Writing backend", 
                project,
                new DatePeriod(new DateTime(2018, 6, 1), new DateTime(2018, 10, 11))
            );

            contribution.AddSkill(skillCSharp);
            contribution.SetEmployee(employeeBob);

            employeeBob.AddContribution(contribution);

            project.AddContribution(contribution);
            
            ProjectRecruting projectRecruting = new ProjectRecruting(
                project, 
                new List<Skill>(){
                    skillAngular,
                    skillCSharp
                }, 
                new List<Employee>(){
                    employeeBob, 
                    employeeDavid
                    }, 
                2);

            report.OutputAboutEmployee(employeeBob);

            report.OutputAboutProject(project);
            
            projectRecruting.Output();
        }
    }
}
