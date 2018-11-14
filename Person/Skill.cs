using System.Collections.Generic;
using ProjectCompany.Activity;

namespace ProjectCompany.Person
{
    public class Skill
    {
        public int Id {get; private set;}
        public string Title { get; private set; }

        public List<EmployeeSkill> EmployeeSkills { get; set;}

        public List<ContributionSkill> ContributionSkills { get; set; }
        public Skill(string title) 
        {
            this.Title = title;
        }
    }
}
