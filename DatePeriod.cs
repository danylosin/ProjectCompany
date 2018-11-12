using System;

namespace ProjectCompany
{
    public class DatePeriod
    {
        public DateTime from { get; private set; }
        public DateTime to { get; private set; }

        public DatePeriod(DateTime from, DateTime to)
        {
            this.from = from;
            this.to = to;
        }
    }
}
