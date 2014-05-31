using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPeriod.Core.DatePieces;

namespace SmartPeriod.Core
{
    public class SelectedCultureEnUs : ISelectedCulture
    {
        public DatePiece Year { get { return new YearPiece("year", "years"); } set { } }
        public DatePiece Month { get { return new MonthPiece("month", "months"); } set { } }
        public DatePiece Day { get { return new DayPiece("day", "days"); } set { } }
        public DatePiece Hour { get { return new HourPiece("hour", "hours"); } set { } }
        public DatePiece Minute { get { return new MinutePiece("minute", "minutes"); } set { } }
        public DatePiece Second { get { return new SecondPiece("second", "seconds"); } set { } }
    }
}
