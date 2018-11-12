using System.Collections.Generic;
using ProjectCompany.Person;
using ProjectCompany;

namespace ProjectCompany.Activity
{
    public class Contribution
    {
        public string Title { get; private set; }
        public Project Project { get; private set; }
        public List<Skill> Skills  { get; private set; }
        public Employee Employee { get; set; }
        public DatePeriod DatePeriod { get; private set; }

        public Contribution(string title, Project project, DatePeriod datePeriod)
        {
            this.Title = title;
            this.Project = project;
            this.Skills = new List<Skill>();
            this.DatePeriod = datePeriod;
        }
        
        public void AddSkill(Skill skill)
        {
            this.Skills.Add(skill);
        }
    }
}
