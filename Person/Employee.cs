using System.Collections.Generic;
using ProjectCompany.Activity;

namespace ProjectCompany.Person
{
    public class Employee
    {
        protected string name;
        protected List<Skill> skills;
        protected List<Contribution> contributions;

        public Employee(string name)
        {
            this.name = name;
            this.contributions = new List<Contribution>();
        }

        public string GetName()
        {
            return this.name;
        }

        public void AddContribution(Contribution contribution)
        {
            this.contributions.Add(contribution);
        }
        public List<Contribution> GetContributions()
        {
            return this.contributions;
        }
        
        public void SetSkills(List<Skill> skills)
        {
            this.skills = skills;
        }

    }
}
