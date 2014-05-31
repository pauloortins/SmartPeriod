using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPeriod.Core.DatePieces;

namespace SmartPeriod.Core.DatePieces
{
    public class SecondPiece : DatePiece
    {
        public SecondPiece(string singular, string plural) : base(singular, plural)
        {
        }

        public override DatePiece ChangeCulture(ISelectedCulture culture)
        {
            return culture.Second;
        }

        public int CalculateSeconds(DateTime startDate, DateTime endDate)
        {
            return (endDate - startDate).Seconds;
        }

        public override string ToStr(DateTime startDate, DateTime endDate, bool showEmpty)
        {
            return DatePieceToString(CalculateSeconds(startDate, endDate), showEmpty);
        }

        public override DateTime Subtract(DateTime startDate, DateTime endDate)
        {
            return startDate.AddSeconds(CalculateSeconds(startDate, endDate));
        }
    }
}
