using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCompany.Models
{
    public class Project
    {
        public int Id {get; private set;}
        public string Title { get; private set; }
        public List<Contribution> Contributions { get; set; }

        public DatePeriod DatePeriod { get; private set; }

        public Project(){}
        public Project(string title, DatePeriod datePeriod)
        {
            this.Title = title;
            this.DatePeriod = datePeriod;
            this.Contributions = new List<Contribution>();
        }
    }
}
