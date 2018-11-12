using ProjectCompany.Activity;
using ProjectCompany.Person;
using System;

namespace ProjectCompany
{
    public class Report
    {
        
        public Report()
        {

        }

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
        }

        public void OutputAboutProject(Project project)
        {
            Console.WriteLine("Info about project " + project.Title);
            foreach (Contribution contribution in project.Contributions) {
                Console.WriteLine(contribution.Title + ". It used next technologies: ");
                this.OutputSkillsOfContribution(contribution);
                Console.WriteLine("The contributor is " + contribution.Employee.Name);
            }
        }

        protected void OutputSkillsOfContribution(Contribution contribution)
        {
            foreach (Skill skill in contribution.Skills) {
                Console.Write(skill.title + " ");
            }
            Console.WriteLine("");
        }
    }
}

