using System.Collections.Generic;
using ProjectCompany.Person;
using ProjectCompany;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ProjectCompany.Activity
{
    public class Contribution
    {
        public int Id {get; private set; }
        public string Title { get; private set; }

        [Column("project_id")]
        public int ProjectId {get; private set; }
        
        [ForeignKey("ProjectId")]
        public Project Project { get; private set; }
        public DateTime from_date { get; private set; }
        public DateTime to_date { get; private set; }

          /* 
        public List<Skill> Skills  { get; private set; }
        public Employee Employee { get; set; }
        public DatePeriod DatePeriod { get; private set; }
        */
        public Contribution(){}
        public Contribution(string title, Project project)
        {
            this.Title = title;
            this.Project = project;
            this.from_date = new DateTime();
            this.to_date = new DateTime();
            //this.Skills = new List<Skill>();
            //this.DatePeriod = datePeriod;
        }
        /* 
        public void AddSkill(Skill skill)
        {
            this.Skills.Add(skill);
        }
        */
    }
}
