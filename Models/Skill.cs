using System.Collections.Generic;

namespace ProjectCompany.Models
{
    public class Skill
    {
        public int Id { get; set;}
        public string Title { get; set; }

        public List<EmployeeSkill> EmployeeSkills { get; set;}

        public List<ContributionSkill> ContributionSkills { get; set; }

        public Skill() {}
        public Skill(string title) 
        {
            this.Title = title;
        }
    }
}
