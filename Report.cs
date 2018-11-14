using ProjectCompany.Activity;
using ProjectCompany.Person;
using System;

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

                //this.OutputSkillsOfContribution(contribution);
                Console.WriteLine();
            }

            Console.WriteLine("_____________");
        }

        public void OutputAboutProject(Project project)
        {
            Console.WriteLine("Info about project " + project.Title);

            foreach (Contribution contribution in project.Contributions) {
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
