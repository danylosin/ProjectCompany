using System;

namespace ProjectCompany
{
    public class DatePeriod
    {
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }

        public DatePeriod(DateTime from, DateTime to)
        {
            this.From = from;
            this.To = to;
        }
    }
}
