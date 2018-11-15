using ProjectCompany.Activity;
using ProjectCompany.Person;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ProjectCompany
{
    public class Report
    {
        public void OutputAboutEmployee(Employee employee)
        {
            Console.WriteLine(employee.Name + "'s contribution: ");
            foreach (Contribution contribution in employee.Contributions) {
                Console.Write(
                    contribution.Title + 
                    " on project " + 
                    contribution.Project.Title +
                    ". It used next technologies: "
                );

                this.OutputSkillsOfContribution(contribution);
                Console.WriteLine();
            }

            Console.WriteLine("_____________");
        }

        public void OutputAboutProject(Project project)
        {
            Console.WriteLine("Info about project " + project.Title);

            foreach (Contribution contribution in project.Contributions) {
                Console.Write(contribution.DatePeriod.From + " to " + contribution.DatePeriod.To + " : ");

                Console.Write(contribution.Title + ". It used next technologies: ");
                this.OutputSkillsOfContribution(contribution);

                Console.WriteLine(". The contributor is " + contribution.Employee.Name);
            }

            Console.WriteLine("_____________");
        }
        
        public void OutputTopProjectsByCountOfContributions(List<Project> projects)
        {
            Console.WriteLine("Top projects by contributins");

            foreach (Project project in projects)
            {
                Console.WriteLine(project.Title + ". Count of contributions " + project.Contributions.Count);
            }

            Console.WriteLine("_____________");
        }
        public void OutputProjectActityByDatePeriod(List<Contribution> contributions, DatePeriod datePeriod)
        {
            Console.WriteLine("Period from " + datePeriod.From + " to " + datePeriod.To);
            foreach (Contribution contribution in contributions) {
                Console.Write(contribution.DatePeriod.From + " to " + contribution.DatePeriod.To + " : ");

                Console.Write(contribution.Title + ". It used next technologies: ");
                this.OutputSkillsOfContribution(contribution);

                Console.WriteLine(". The contributor is " + contribution.Employee.Name);
            }
            Console.WriteLine("_____________");
        }
        
        public void OutputProjectContributionsByYear(List<Contribution> contributions, DateTime dateTime)
        {
            foreach (Contribution contribution in contributions) {
                Console.Write(contribution.DatePeriod.From + " to " + contribution.DatePeriod.To + " : ");

                Console.Write(contribution.Title + ". It used next technologies: ");
                this.OutputSkillsOfContribution(contribution);

                Console.WriteLine(". The contributor is " + contribution.Employee.Name);
            }
            Console.WriteLine("_____________");
        }

        protected void OutputSkillsOfContribution(Contribution contribution)
        {
            foreach (ContributionSkill contributionSkill in contribution.ContributionSkills) {
                Console.Write(contributionSkill.Skill.Title + " ");
            }
        }
    }
}
