using System.Collections.Generic;
using ProjectCompany;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectCompany.Models
{
    public class Contribution
    {
        public int Id {get; set; }
        
        [Required]
        public string Title { get; set; }

        [Column("project_id")]
        public int ProjectId {get; set; }

        public Project Project { get; set; }

        [Column("employee_id")]
        [Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public DatePeriod DatePeriod { get; set; }

        public List<ContributionSkill> ContributionSkills { get; set; }

        public Contribution(){}

        public Contribution(string title, Project project, Employee employee, DatePeriod datePeriod)
        {
            this.Title = title;
            this.Project = project;
            this.DatePeriod = datePeriod;
            this.Employee = employee;
            this.ContributionSkills = new List<ContributionSkill>();
        }
    }
}
