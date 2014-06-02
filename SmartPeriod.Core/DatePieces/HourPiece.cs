using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPeriod.Core.DatePieces;

namespace SmartPeriod.Core.DatePieces
{
    public class HourPiece : DatePiece
    {
        public HourPiece(string singular, string plural) : base(singular, plural)
        {
        }

        public override DatePiece ChangeCulture(ISelectedCulture culture)
        {
            return culture.Hour;
        }

        public int CalculateHours(DateTime startDate, DateTime endDate)
        {
            return (int)(endDate - startDate).TotalHours;
        }

        public override string ToStr(DateTime startDate, DateTime endDate, bool showEmpty, string separator)
        {
            return DatePieceToString(CalculateHours(startDate, endDate), showEmpty, separator);
        }

        public override DateTime Subtract(DateTime startDate, DateTime endDate)
        {

            return startDate.AddHours(CalculateHours(startDate, endDate));
        }
    }
}
