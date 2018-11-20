using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCompany.Models
{
    public class Project
    {
        public int Id {get; private set;}
        [Required]
        public string Title { get; set; }
        public List<Contribution> Contributions { get; set; }

        [Required]
        public DatePeriod DatePeriod { get; set; }

        public Project(){}
        public Project(string title, DatePeriod datePeriod)
        {
            this.Title = title;
            this.DatePeriod = datePeriod;
            this.Contributions = new List<Contribution>();
        }
    }
}
