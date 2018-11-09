using System;

namespace ProjectCompany
{
    public class DatePeriod
    {
        protected DateTime from;
        protected DateTime to;

        public DatePeriod(DateTime from, DateTime to)
        {
            this.from = from;
            this.to = to;
        }
    }
}