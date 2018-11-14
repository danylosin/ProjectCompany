using System.Collections.Generic;
using ProjectCompany.Activity;

namespace ProjectCompany.Person
{
    public class Employee
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Skill> Skills { get; private set; }
        public List<Contribution> Contributions { get; private set; }

        public Employee(string name)
        {
            this.Name = name;
            this.Contributions = new List<Contribution>();
            this.Skills = new List<Skill>();
        }

        public void AddContribution(Contribution contribution)
        {
            if (!this.Contributions.Contains(contribution)) {
                this.Contributions.Add(contribution);
            }
        }
        
        public void AddSkill(Skill skill)
        {
            if (!this.Skills.Contains(skill)) {
                this.Skills.Add(skill);
            }
        }
    }
}
