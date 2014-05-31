using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPeriod.Core.DatePieces;

namespace SmartPeriod.Core.DatePieces
{
    public class DayPiece : DatePiece
    {
        public DayPiece(string singular, string plural) : base(singular, plural)
        {

        }

        public override DatePiece ChangeCulture(ISelectedCulture culture)
        {
            return culture.Day;
        }

        public override string ToStr(DateTime startDate, DateTime endDate, bool showEmpty)
        {
            return DatePieceToString((endDate-startDate).Days, showEmpty);
        }

        public override DateTime Subtract(DateTime startDate, DateTime endDate)
        {
            return startDate.AddDays((endDate - startDate).Days);
        }
    }
}
