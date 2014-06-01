using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPeriod.Core.DatePieces;

namespace SmartPeriod.Core.DatePieces
{
    public class MonthPiece : DatePiece
    {
        public MonthPiece(string singular, string plural) : base(singular, plural)
        {            
        }

        public override DatePiece ChangeCulture(ISelectedCulture culture)
        {
            return culture.Month;
        }

        public int CalculateMonths(DateTime startDate, DateTime endDate)
        {
            var months = 0;

            while (startDate.AddMonths(1) <= endDate)
            {
                startDate = startDate.AddMonths(1);
                months += 1;
            }

            return months;
        }

        public override string ToStr(DateTime startDate, DateTime endDate, bool showEmpty, string separator)
        {
            return DatePieceToString(CalculateMonths(startDate, endDate), showEmpty, separator);
        }

        public override DateTime Subtract(DateTime startDate, DateTime endDate)
        {
            return startDate.AddMonths(CalculateMonths(startDate, endDate));
        }
    }
}
