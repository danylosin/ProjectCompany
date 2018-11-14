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

        public Project Project { get; private set; }

        [Column("employee_id")]
        public int EmployeeId { get; private set; }

        public Employee Employee { get; private set; }

        public DateTime from_date { get; private set; }
        public DateTime to_date { get; private set; }

        //public DatePeriod DatePeriod { get; private set; }   
        public List<ContributionSkill> ContributionSkills { get; set; }

        public Contribution(){}

        public Contribution(string title, Project project)
        {
            this.Title = title;
            this.Project = project;
            this.from_date = new DateTime();
            this.to_date = new DateTime();
        }
    }
}
