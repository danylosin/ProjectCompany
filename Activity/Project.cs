using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProjectCompany.Activity
{
    public class Project
    {
        public int Id {get; private set;}
        public string Title { get; private set; }
        //public DatePeriod DatePeriod { get; private set; }
        [InverseProperty("Project")]
        public List<Contribution> Contributions { get; set; }
        public DateTime from_date { get; private set; }
        public DateTime to_date { get; private set; }

        public Project(string title)
        {
            this.Title = title;
            this.from_date = new DateTime();
            this.to_date = new DateTime();
            //this.DatePeriod = datePeriod;
            this.Contributions = new List<Contribution>();
        }

        public void SetContributions(List<Contribution> contributions)
        {
            //this.Contributions = contributions;
        }

        public void AddContribution(Contribution contribution)
        {
            //this.Contributions.Add(contribution);
        }
    }
}
