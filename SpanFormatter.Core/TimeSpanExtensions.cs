using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpanFormatter.Core
{
    public static class TimeSpanExtensions
    {
        public static int GetYears(this TimeSpan timespan)
        {
            return (int)((double)timespan.Add(new TimeSpan(1, 0, 0, 0)).Days / 365.2425);
        }

        public static int GetMonths(this TimeSpan timespan)
        {
            return (int)((double)timespan.Add(new TimeSpan(1, 0, 0, 0)).Days / 30.436875);
        }
    }
}
