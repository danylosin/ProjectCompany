using System.Collections.Generic;
using System;
using ProjectCompany.Models;

namespace ProjectCompany.Seeds
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(AppContext appContext)
        {
            List<Skill> skills = new List<Skill>() {
                new Skill("Python"),
                new Skill("C#"),
                new Skill("C++"),
                new Skill("Angular"),
                new Skill("React"),
                new Skill("Bootstrap"),
                new Skill("PhP")
            };

            List<Project> projects = new List<Project>();

            for (int i = 1; i <= 10; i++) {
                DateTime from = new DateTime(2017, 01, 01).AddMonths(i);
                DateTime to = new DateTime(2017, 08, 01).AddMonths(i);
                projects.Add(new Project("Project #" + i, new DatePeriod(from, to)));
            }

            List<Employee> employees = new List<Employee>();
            
            for (int i = 1; i <= 10; i++) {
                employees.Add(new Employee("Employee #" + i));
            }
     
     
            appContext.skills.AddRange(skills);
            appContext.projects.AddRange(projects);
            appContext.employees.AddRange(employees);
            
            appContext.SaveChanges();
        }
    }
}