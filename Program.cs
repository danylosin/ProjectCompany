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
                        .employees.Include(e => e.Contributions)
                        .Include(e => e.EmployeeSkills)
                        .ThenInclude(es => es.Skill)
                        .First();
                        
                //Console.Write(employeeDan.EmployeeSkills.First().Skill.Title);
                report.OutputAboutEmployee(employeeDan);
            }
            

            //DatePeriod datePeriod = new DatePeriod(new DateTime(2018, 6, 1), new DateTime(2018, 10, 11));
            /* 
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
            */

            //report.OutputAboutProject(project);

            //projectRecruting.Output();
        }
    }
}
