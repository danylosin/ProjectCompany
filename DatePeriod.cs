using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCompany
{
    public class DatePeriod
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public DatePeriod(DateTime from, DateTime to)
        {
            this.From = from;
            this.To = to;
        }
    }
}
