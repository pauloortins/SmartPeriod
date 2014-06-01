using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPeriod.Core.DatePieces;

namespace SmartPeriod.Core.DatePieces
{
    public class MinutePiece : DatePiece
    {
        public MinutePiece(string singular, string plural) : base(singular, plural)
        {
        }

        public override DatePiece ChangeCulture(ISelectedCulture culture)
        {
            return culture.Minute;
        }

        public int CalculateMinutes(DateTime startDate, DateTime endDate)
        {
            return (endDate - startDate).Minutes;
        }

        public override string ToStr(DateTime startDate, DateTime endDate, bool showEmpty, string separator)
        {
            return DatePieceToString(CalculateMinutes(startDate, endDate), showEmpty, separator);
        }

        public override DateTime Subtract(DateTime startDate, DateTime endDate)
        {
            return startDate.AddMinutes(CalculateMinutes(startDate, endDate));
        }
    }
}
