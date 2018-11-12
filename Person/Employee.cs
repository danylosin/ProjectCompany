using System.Collections.Generic;
using ProjectCompany.Activity;

namespace ProjectCompany.Person
{
    public class Employee
    {
        public string Name { get; private set; }
        public List<Skill> Skills { get; private set; }
        public List<Contribution> Contributions { get; private set; }
        public float Competensy { get; private set; }

        public Employee(string name)
        {
            this.Name = name;
            this.Contributions = new List<Contribution>();
            this.Skills = new List<Skill>();
        }

        public void AddContribution(Contribution contribution)
        {
            this.Contributions.Add(contribution);
        }
        
        public void AddSkill(Skill skill)
        {
            this.Skills.Add(skill);
        }

        public void CalculateEmployeeCompetensy(List<Skill> skills)
         {
            int quanitityOfMatchedSkills = 0;
            foreach (Skill skill in skills) {
                if (this.Skills.Contains(skill)) {
                    quanitityOfMatchedSkills++;
                }
            }
            int competensy = quanitityOfMatchedSkills / skills.Count;
            
            this.Competensy = competensy;
         }
    }
}
