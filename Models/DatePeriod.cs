using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCompany.Models
{
    public class DatePeriod
    {
        [DataType(DataType.Date)]
        public DateTime From { get; set; }
        [DataType(DataType.Date)]
        public DateTime To { get; set; }

        public DatePeriod(){}
        public DatePeriod(DateTime from, DateTime to)
        {
            this.From = from;
            this.To = to;
        }
    }
}
