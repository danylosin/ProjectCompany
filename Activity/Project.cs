using System.Collections.Generic;

namespace ProjectCompany.Activity
{
    public class Project
    {
        protected string title;
        protected DatePeriod datePeriod;
        protected List<Contribution> contributions;

        public Project(string title, DatePeriod datePeriod)
        {
            this.title = title;
            this.datePeriod = datePeriod;
            this.contributions = new List<Contribution>();
        }

        public void AddContribution(Contribution contribution)
        {
            this.contributions.Add(contribution);
        }

        public void AddContributions(params Contribution[] contributions)
        {
            this.contributions.AddRange(new List<Contribution>(contributions));
        }

        public string GetTitle()
        {
            return this.title;
        }
    }
}