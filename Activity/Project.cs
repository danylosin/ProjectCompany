using System.Collections.Generic;

namespace ProjectCompany.Activity
{
    public class Project
    {
        public string Title { get; private set; }
        public DatePeriod DatePeriod { get; private set; }
        public List<Contribution> Contributions { get; set; }

        public Project(string title, DatePeriod datePeriod)
        {
            this.Title = title;
            this.DatePeriod = datePeriod;
            this.Contributions = new List<Contribution>();
        }

        public void SetContributions(List<Contribution> contributions)
        {
            this.Contributions = contributions;
        }

        public void AddContribution(Contribution contribution)
        {
            this.Contributions.Add(contribution);
        }
    }
}
