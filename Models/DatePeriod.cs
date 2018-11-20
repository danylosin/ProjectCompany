using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCompany.Models
{
    public class DatePeriod
    {
        [Required]
        [DataType(DataType.Date, ErrorMessage="Invalid date")]
        public DateTime From { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage="Invalid date")]
        public DateTime To { get; set; }

        public DatePeriod(){}
        public DatePeriod(DateTime from, DateTime to)
        {
            this.From = from;
            this.To = to;
        }
    }
}
